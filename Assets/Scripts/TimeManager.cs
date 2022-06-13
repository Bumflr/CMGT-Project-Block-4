using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    //Script which manages the flow of time
    //Ok not anymore lol it turned into the glue holding every piece of code together which is fucking stupid but haha spaghetti code go brrr

    public Text counterDayText;
    public Text turnsText;
    public Slider SliderTime;
    public Button nextStepButton;
    public Image clock;

    public int actionPoints;
    public float lerpTime;
    public float timeLimit;


    private float currentTime; //0 to 1440
    private int currentActionPoints;
    private int currentDay;
    public float currentStorm;
    private Vector3 currentRotation;

    public ApplianceManager am;
    public ResourceManager rm;
    public EfficiencyManager em;
    public EndOfDayResultsScript eodr;

    float newHunger;
    float newCleanliness;
    float newBoredom;
    float newElectricity;
    float newTime;
    float newRotation;
    float newStorm;

    private float maxStorm;

    float difference;
    static float maxTime = 1440;

    public static TimeManager Instance;

    private bool buttonPressed;

    //This is the Game Over Screen
    public GameObject FailScreen;

    public GameObject lighting;
    private float percentageNextStep = 1;

    [HideInInspector] public bool motorsOff;

    private void Awake()
    {

        Instance = this;

        currentActionPoints = actionPoints;
        currentRotation = new Vector3(-30, -56, 0);

        newRotation = currentRotation.x;
        newElectricity = rm.electricity;
        newBoredom = rm.boredom;
        newCleanliness = rm.cleanliness;
        newHunger = rm.hunger;
        newStorm = currentStorm;
        maxStorm = currentStorm;
        difference = maxTime / actionPoints;
        gameObject.SetActive(true);

        rm.oldElectricity = rm.electricity;
        rm.oldHunger = rm.hunger;
        rm.oldBoredom = rm.boredom;
        rm.oldCleanliness = rm.cleanliness;
        rm.oldScrap = rm.scrap;
    }

    public void NextTurn()
    {
        buttonPressed = true;
    }

    void Update()
    {
        //Holy shit this really has turned to spaghetti code now, making use of so many different scripts which used to have different functions and now not anymore bruuuuuuuuuuuuh
        //ah well
        if (percentageNextStep < 0.9999f)
        {
            nextStepButton.transform.gameObject.GetComponentInChildren<Text>().text = "WAITING..";
        }
        else
        {
            nextStepButton.transform.gameObject.GetComponentInChildren<Text>().text = "NEXT TURN";
        }

        if (buttonPressed && percentageNextStep >= 0.9999f)
        {
            buttonPressed = false;
            newTime = currentTime + (maxTime / actionPoints);
            
            newRotation = currentRotation.x + ((maxTime / actionPoints) / 4);
            newElectricity = rm.electricity - em.totalElec;


            newBoredom = em.totalBored == 0 ? rm.boredom - rm.statDepletionRate : rm.boredom +em.totalBored;
            newCleanliness = em.totalClean == 0 ? rm.cleanliness - rm.statDepletionRate : rm.cleanliness + em.totalClean;
            newHunger = em.totalHungy == 0 ? rm.hunger - rm.statDepletionRate : rm.hunger + em.totalHungy;

            //tm.ActionPassed();
            currentActionPoints--;

            newStorm = em.motorOn ? currentStorm - 1 : currentStorm - 2;
        }
        else
        {
            buttonPressed = false;
        }

        if (currentTime > maxTime)
        {
            currentTime = 0;
            newTime = 0 + (maxTime / actionPoints);

            //currentRotation.x = -30;
            newRotation = -30 + ((maxTime / actionPoints) / 4);

            currentActionPoints = actionPoints;

            currentDay++;
            rm.scrap++;
            NextDayTransition();
        }

        currentRotation.x = ValueLerpGet(currentRotation.x, newRotation);

        lighting.transform.eulerAngles = currentRotation;
        clock.transform.eulerAngles = new Vector3(0, 0, currentRotation.x - 40);

        currentTime = ValueLerpGet(currentTime, newTime);

        float percentageDay = currentTime / 1440;
        if (maxStorm != currentStorm) percentageNextStep =  newTime == 0 ? 0 : 1 - ((newTime - currentTime) / difference);

        am.SetSliderValues(percentageNextStep);

        rm.electricity = ValueLerpGet(rm.electricity, newElectricity);

        rm.hunger = ValueLerpGet(rm.hunger, newHunger);

        rm.boredom = ValueLerpGet(rm.boredom, newBoredom);

        rm.cleanliness = ValueLerpGet(rm.cleanliness, newCleanliness);

        float h = rm.hunger / 100;
        float b = rm.boredom / 100;
        float c = rm.cleanliness / 100;
        rm.SetSliderValues(h, c, b);


        currentStorm = ValueLerpGet(currentStorm, newStorm);

        SliderTime.value = 1 - (currentStorm / maxStorm);

        if (currentStorm <= 0)
        {
            RenderSettings.fogDensity = 0.03f;
        }

    
        counterDayText.text = ("Day: " + currentDay.ToString());
        turnsText.text = currentActionPoints.ToString();
    }

    public float PercentageGet(TimeSpan localTimeSpan, float days)
    {
        return 1 - (((float)localTimeSpan.Days * 24 * 60) + ((float)localTimeSpan.Hours * 60) + (float)localTimeSpan.Minutes) / (1440 * days);
    }
    
    public float ValueLerpGet(float inputValue, float newValue)
    {
        inputValue = Mathf.Lerp(inputValue, newValue, lerpTime / timeLimit * Time.deltaTime);

        return inputValue;
    }

    public void NextDayTransition()
    {
        float e = rm.electricity - rm.oldElectricity;
        float h = rm.hunger - rm.oldHunger;
        float b = rm.boredom - rm.oldBoredom;
        float c = rm.cleanliness - rm.oldCleanliness;
        float s = rm.scrap - rm.oldScrap;
        float d = currentStorm / actionPoints;

        eodr.GetData(e, h, b, c, s, d, currentDay - 1);

        rm.oldElectricity = rm.electricity;
        rm.oldHunger = rm.hunger;
        rm.oldBoredom = rm.boredom;
        rm.oldCleanliness = rm.cleanliness;
        rm.oldScrap = rm.scrap;
    }

}


