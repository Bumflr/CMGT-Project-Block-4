using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiTask : MonoBehaviour
{
  /*  private string title;
    private int maxAmountOfDays;
    private int currentAmountOfDays;
    private float dangerPercentage;
    private TimeSpan localTimeSpan;

    private Slider slider;
    private Image sliderFillImage;
    private Color defaultColor;
    private TimeManager timeManager;

    public TextMeshProUGUI amountOfDaysText;
    public Text nextStepText;
    public Text titleText;

    private void Awake()
    {
        slider = GetComponentInChildren<Slider>();
        sliderFillImage = slider.fillRect.gameObject.GetComponent<Image>();
        defaultColor = sliderFillImage.color;
        timeManager = TimeManager.Instance;
    }

    public void SetData(string title, int maxAmountOfDays, float dangerPercentage, Uses step)
    {
        this.title = title;
        this.maxAmountOfDays = maxAmountOfDays;
        this.dangerPercentage = dangerPercentage;
        currentAmountOfDays = maxAmountOfDays;

        titleText.text = title;
        amountOfDaysText.text = "Days Left: " + maxAmountOfDays.ToString();
        //SetNextStep(step);
    }

    public void DayPassed()
    {
        currentAmountOfDays--;

        amountOfDaysText.text = currentAmountOfDays != 1 ? "Turns Left: " + currentAmountOfDays.ToString() : "Turn Left: " + currentAmountOfDays.ToString();
    }

   /* public void SetNextStep(Uses step)
    {
        nextStepText.text = "Next Objective: " + step.ToString();
    }*/

    /*public void SetCompletion()
    {
        currentAmountOfDays = maxAmountOfDays;
        DayPassed();
        localTimeSpan = new TimeSpan(0, 0, 0, 0, 0);
    }

    private void Update()
    {
        //localTimeSpan = timeManager.AddTime(localTimeSpan);
        slider.value = timeManager.PercentageGet(localTimeSpan, maxAmountOfDays);

        if (slider.value < dangerPercentage)
        {
            sliderFillImage.color = Color.red;
        }
        else
        {
            sliderFillImage.color = defaultColor;
        }
    }*/
}
