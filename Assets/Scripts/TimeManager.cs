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

    public float lerpTime;
    public float timeLimit;
    public int currentDay;

    [HideInInspector] public ApplianceManager am;
    [HideInInspector] public ResourceManager rm;

    //public static float maxTime = 1440;

    public static TimeManager Instance;

    public GameObject lighting;
    private float percentageNextStep = 1;
    bool fastForwarding;

    private void Awake()
    {
        Instance = this;
        gameObject.SetActive(true);
    }

    public void NextTurn()
    {
        if (percentageNextStep >= 0.9999f)
        {
            if (fastForwarding)
            {
                timeLimit *= 2f;
            }
            fastForwarding = false;

            rm.SetUpNextDay();
        }
        else if (!fastForwarding)
        {
            //Ok so it's still counting so speed it up.
            timeLimit = timeLimit / 2;
            fastForwarding = true;
        }
    }


    void Update()
    {
        //Holy shit this really has turned to spaghetti code now, making use of so many different scripts which used to have different functions and now not anymore bruuuuuuuuuuuuh
        //ah well

        //ok its better now ig
        ValuesAffectedByTime();

        if (percentageNextStep < 0.9999f)
        {
            nextStepButton.transform.gameObject.GetComponentInChildren<Text>().text = "WAITING..";
        }
        else
        {
            nextStepButton.transform.gameObject.GetComponentInChildren<Text>().text = "NEXT TURN";
        }

        //Reset the timer after a day passed
        if (rm.currentTime > 1440)
        {
            rm.currentTime = 0;
            rm.newTime = 0 + (1440 / rm.actionPoints);
            rm.newRotation = -30 + ((1440 / rm.actionPoints) / 4);
            rm.currentActionPoints = rm.actionPoints;

            currentDay++;
            rm.scrap++;
            rm.NextDayTransition();
        }

        //Set the lighing to the time
        lighting.transform.eulerAngles = rm.currentRotation;
        //Rotate the clock
        clock.transform.eulerAngles = new Vector3(0, 0, rm.currentRotation.x - 40);


        float percentageDay = rm.currentTime / 1440;
        //Ok so if it ain't the actual first turn THEN set percentageNextStep to the difference between the newtime and the old one.
        //This basically calculates the green bar
        if (rm.maxStorm != rm.currentStorm) percentageNextStep = rm.newTime == 0 ? 0 : 1 - ((rm.newTime - rm.currentTime) / rm.difference);

        am.SetSliderValues(percentageNextStep);
        SliderTime.value = 1 - (rm.currentStorm / rm.maxStorm);

        if (rm.currentStorm <= 0)
        {
            RenderSettings.fogDensity = 0.03f;
        }

        counterDayText.text = ("Day: " + currentDay.ToString());
        turnsText.text = rm.currentActionPoints.ToString();
    }

    void ValuesAffectedByTime()
    {
        rm.currentRotation.x = ValueLerpGet(rm.currentRotation.x, rm.newRotation);

        rm.currentTime = ValueLerpGet(rm.currentTime, rm.newTime);

        rm.electricity = ValueLerpGet(rm.electricity, rm.newElectricity);

        rm.hunger = ValueLerpGet(rm.hunger, rm.newHunger);

        rm.boredom = ValueLerpGet(rm.boredom, rm.newBoredom);

        rm.cleanliness = ValueLerpGet(rm.cleanliness, rm.newCleanliness);

        rm.currentStorm = ValueLerpGet(rm.currentStorm, rm.newStorm);
    }

    //This needs to go
    public float PercentageGet(TimeSpan localTimeSpan, float days)
    {
        return 1 - (((float)localTimeSpan.Days * 24 * 60) + ((float)localTimeSpan.Hours * 60) + (float)localTimeSpan.Minutes) / (1440 * days);
    }
    
    public float ValueLerpGet(float inputValue, float newValue)
    {
        inputValue = Mathf.Lerp(inputValue, newValue, lerpTime / timeLimit * Time.deltaTime);

        return inputValue;
    }



}


