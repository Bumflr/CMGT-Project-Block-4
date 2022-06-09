using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{
    //Holds all of the resources as well as the UI 

    public static ResourceManager Instance;

    public Text electricityText;
    public Text scrapText;

    public GameObject failscreen;


    public float electricity, hunger, cleanliness, boredom, scrap;

    public float statDepletionRate;

    public Slider hungerSlider;
    public Slider cleanSlider;
    public Slider boredSlider;

    public float oldElectricity, oldHunger, oldCleanliness, oldBoredom, oldScrap;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;

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


        if (electricity <= 0 || hunger <= 0 || cleanliness <= 0 || boredom <= 0)
        {
            failscreen.SetActive(true);
        }
    }

    public void SetSliderValues(float hValue, float cValue, float bValue)
    {
        hungerSlider.value = hValue;
        cleanSlider.value = cValue;
        boredSlider.value = bValue;
    }


}
