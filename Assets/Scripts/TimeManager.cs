using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    //Script which manages the flow of time
    
    //make these private and have the script find them on their own
    public Text timerText;
    public Text counterDayText;
    public Slider SliderTime;

    public static TimeManager Instance;
    public System.TimeSpan timeSpan = new System.TimeSpan(0, 0, 0, 0, 0);
    public System.TimeSpan StormTime = new System.TimeSpan(StormArrivalDate, 0, 0, 0, 0);
    public float timeRate;
    private float milliseconds;


    //If you want to change when the storm arrives, change it here
    //NOTE: DON'T CHANGE TO 1
    public static int StormArrivalDate = 4;

    //This is the Game Over Screen
    public FailScreen FailScreen;

    private int currentDay;
    private int currentHour;
    private int currentMinute;

    public event EventHandler MinutePassed;
    public event EventHandler HourPassed;
    public event EventHandler DayPassed;

    //Very hacky implementation and will probably be moved to a day and night cycle script
    public GameObject lighting;
    float rotationSpeed;

    [HideInInspector] public bool motorsOff;

    private void Awake()
    {
        Instance = this;
        rotationSpeed = 360 / 24f / 60;

        gameObject.SetActive(true);
    }

    void Update()
    {
        milliseconds = Time.deltaTime * 1000 * timeRate;

        timeSpan = AddTime(timeSpan);

        if (motorsOff)
        {
            StormTime -= new System.TimeSpan(0, 0, 0, 0, (int)milliseconds);
        }

        //Storm progression code START
        float totalPercentage = (((float)timeSpan.Days * 24 * 60) + ((float)timeSpan.Hours * 60) + ((float)timeSpan.Minutes)) / (((float)StormTime.Days * 24 * 60) + ((float)StormTime.Hours * 60) + ((float)StormTime.Minutes));
        SliderTime.value = totalPercentage;

        float percentageDay = (((float)timeSpan.Hours * 60) + (float)timeSpan.Minutes) / (1440);
        //Storm progression code END

        if (currentMinute != timeSpan.Minutes)
        {
            currentMinute = timeSpan.Minutes;
            lighting.transform.Rotate(new Vector3(1f, 0, 0) * rotationSpeed);

            MinutePassed?.Invoke(this, EventArgs.Empty);
        }

        if (currentHour != timeSpan.Hours)
        {
            currentHour = timeSpan.Hours;
            HourPassed?.Invoke(this, EventArgs.Empty);
        }

        if (currentDay == (float)timeSpan.Days)
        {
            currentDay++;
            DayPassed?.Invoke(this, EventArgs.Empty);
        }

        //when the storm reaches the player, they lose
        //Should also go into another script
        if (totalPercentage >= 1)
        {
            FailScreen.setup();
            timeRate = 0;
        }

        counterDayText.text = ("Day: " + currentDay.ToString());
        timerText.text = percentageDay.ToString("F2");
    }

    public float PercentageGet(TimeSpan localTimeSpan, float days)
    {
        return (((float)localTimeSpan.Days * 24 * 60) + ((float)localTimeSpan.Hours * 60) + (float)localTimeSpan.Minutes) / (1440 * days);
    }

    public TimeSpan AddTime(TimeSpan timeSpan)
    {
        timeSpan += new System.TimeSpan(0, 0, 0, 0, (int)milliseconds);
        return timeSpan;
    }

}


