using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public string myFormat;

    public Text timerText;
    public Text counterDayText;

    public Slider SliderTime;

    public static TimeManager Instance;
    public System.TimeSpan timeSpan = new System.TimeSpan(0, 0, 0, 0, 0);
    public System.TimeSpan StormTime = new System.TimeSpan(StormArrivalDate, 0, 0, 0, 0);

    //If you want to change when the storm arrives, change it here
    //NOTE: DON'T CHANGE TO 1
    public static int StormArrivalDate = 4;

    //This is the Game Over Screen
    public FailScreen FailScreen;

    public int currentDay;
    public int currentMinute;

    public float timeRate;

    public event EventHandler minutePassed;

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
        float milliseconds = Time.deltaTime * 1000 * timeRate;
        
        timeSpan += new System.TimeSpan(0, 0, 0, 0, (int)milliseconds);

        if (motorsOff)
        {
            StormTime -= new System.TimeSpan(0, 0, 0, 0, (int)milliseconds);
        }

        //Storm progression code START
        float percentage = (((float)timeSpan.Days * 24 * 60) + ((float)timeSpan.Hours * 60) + ((float)timeSpan.Minutes)) / (((float)StormTime.Days * 24 * 60) + ((float)StormTime.Hours * 60) + ((float)StormTime.Minutes));
        SliderTime.value = percentage;

        float percentageDay = (((float)timeSpan.Hours * 60) + (float)timeSpan.Minutes) / (1440);
        //Storm progression code END

        if (currentMinute != timeSpan.Minutes)
        {
            currentMinute = timeSpan.Minutes;
            lighting.transform.Rotate(new Vector3(1f, 0, 0) * rotationSpeed);

            minutePassed?.Invoke(this, EventArgs.Empty);
        }

        if (currentDay == (float)timeSpan.Days)
        {
            currentDay++;
        }

        //when the storm reaches the player, they lose

        if (percentage >= 1)
        {
            FailScreen.setup();
            timeRate = 0;
        }

        counterDayText.text = ("Day: " + currentDay.ToString());
        timerText.text = percentageDay.ToString();
    }


    public void AddTime(int value)
    {
        timeSpan += new System.TimeSpan(value, 0, 0);
    }

}


