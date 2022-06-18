using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{
    //Holds all of the resources as well as the UI 
    [HideInInspector] public GameManager gm;

    public Text electricityText;
    public Text scrapText;

    public GameObject failscreen;
    public Text failScreenText;

    public float statDepletionRate;

    public float electricity, hunger, cleanliness, boredom, scrap;
    [HideInInspector] public float oldElectricity, oldHunger, oldCleanliness, oldBoredom, oldScrap;
    [HideInInspector] public float newElectricity, newHunger, newCleanliness, newBoredom, newTime, newRotation, newStorm;

    public int actionPoints;
    public float currentStorm;

    [HideInInspector] public int currentActionPoints;
    [HideInInspector] public Vector3 currentRotation;
    [HideInInspector] public float maxStorm;
    [HideInInspector] public float difference;
    [HideInInspector] public float currentTime; //0 to 1440


    public Slider hungerSlider;
    public Slider cleanSlider;
    public Slider boredSlider;

    // Start is called before the first frame update
    void Awake()
    {
        InitializeValues();

        electricity = 100;
        hunger = 100;
        cleanliness = 100;
        boredom = 100;
        scrap = 0;
    }

    private void Update()
    {
        electricityText.text = electricity.ToString("F2") + " kwH";
        scrapText.text = scrap.ToString("F0");

        electricity = Mathf.Clamp(electricity, 0, 420);
        hunger = Mathf.Clamp(hunger, 0, 100);
        cleanliness = Mathf.Clamp(cleanliness, 0, 100);
        boredom = Mathf.Clamp(boredom, 0, 100);

        float h = hunger / 100;
        float b = boredom / 100;
        float c = cleanliness / 100;

        SetSliderValues(h, c, b);

        if (electricity <= 0 || hunger <= 0 || cleanliness <= 0 || boredom <= 0)
        {
            if (electricity <= 0)
            {
                failScreenText.text = "Ran out of electricity!";
            }
            else if (hunger <= 0)
            {
                failScreenText.text = "Starved to death!";

            }
            else if (cleanliness <= 0)
            {
                failScreenText.text = "You stanky!";

            }
            else if (boredom <= 0)
            {
                failScreenText.text = "Died of cringe!";
            }

            failscreen.SetActive(true);
        }
    }

    public void InitializeValues()
    {
        currentActionPoints = actionPoints;
        currentRotation = new Vector3(-30, -56, 0);

        newRotation = currentRotation.x;
        newElectricity = electricity;
        newBoredom = boredom;
        newCleanliness = cleanliness;
        newHunger = hunger;
        newStorm = currentStorm;
        maxStorm = currentStorm;
        difference = 1440 / actionPoints;

        oldElectricity = electricity;
        oldHunger = hunger;
        oldBoredom = boredom;
        oldCleanliness = cleanliness;
        oldScrap = scrap;

    }

    public void SetUpNextDay()
    {
        newTime = currentTime + (1440 / actionPoints);

        newRotation = currentRotation.x + ((1440 / actionPoints) / 4);
        newElectricity = electricity - gm.em.totalElec;


        newBoredom = gm.em.totalBored == 0 ? boredom - statDepletionRate : boredom + gm.em.totalBored;
        newCleanliness = gm.em.totalClean == 0 ? cleanliness - statDepletionRate : cleanliness + gm.em.totalClean;
        newHunger = gm.em.totalHungy == 0 ? hunger - statDepletionRate : hunger + gm.em.totalHungy;

        currentActionPoints--;

        newStorm = gm.em.motorOn ? currentStorm - 1 : currentStorm - 2;
    }

    public void NextDayTransition()
    {
        float e = electricity - oldElectricity;
        float h = hunger - oldHunger;
        float b = boredom -oldBoredom;
        float c = cleanliness - oldCleanliness;
        float s = scrap - oldScrap;
        float d = currentStorm / actionPoints;

        gm.eodr.GetData(e, h, b, c, s, d, gm.tm.currentDay - 1);

        oldElectricity = electricity;
        oldHunger = hunger;
        oldBoredom = boredom;
        oldCleanliness = cleanliness;
        oldScrap = scrap;
    }

    public void SetSliderValues(float hValue, float cValue, float bValue)
    {
        hungerSlider.value = hValue;
        cleanSlider.value = cValue;
        boredSlider.value = bValue;
    }


}
