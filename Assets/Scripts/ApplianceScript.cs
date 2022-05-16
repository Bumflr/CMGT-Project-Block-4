using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Honestly an enum is just an array of indexes, but with a name assigned to it so its a bit more readable.
public enum ApplianceState
{
    ON,
    OFF,
    UNPLUGGED
}

public class ApplianceScript : MonoBehaviour
{
    private ResourceManager ResourceManager;

    [SerializeField]
    private float kwH;

    private Material offMat;
    private Material onMat;
    private Material unplugMat;
    

    //wind objects
    public GameObject Object1;
    public GameObject Object2;
    public GameObject Object3;

    //public GameObject canvas;

    public bool isHydrogenAppliance;
    public bool isManualAppliance;
    public bool isEngineOrMotors;

    public float amountOfSecondsDoingTask;

    public ApplianceState state;

    private bool timer;
    private bool otherTimer;


    private void Awake()
    {
        //Resources is a folder where you can put stuff and get stuff
        //Dont use it too much however, since it isn't that performant
        offMat = Resources.Load<Material>("OffMat");
        onMat = Resources.Load<Material>("OnMat");
        unplugMat = Resources.Load<Material>("UnpluggedMat");

        ResourceManager = FindObjectOfType<ResourceManager>();
        state = ApplianceState.UNPLUGGED;
        SetMat();

        //Is like a just calling a function but a bit different
        StartCoroutine(SearchForInstance());
    }
   
    private void DeductElectricity(object sender, EventArgs e)
    {
        //kilo watt minute
        float kwM = kwH / 60;
        //kilo watt minute if the things turned off
        float kwMOff = kwM * 0.3f;

        if (state == ApplianceState.ON)
        {
            ResourceManager.electricity -= kwM;

            if (isHydrogenAppliance)
                ResourceManager.hydrogen += 5;

            //if it is an appliances that requires work to use, it fastforwards time
            if (isManualAppliance)
            {
                if (timer == false && !otherTimer)
                {
                    TimeManager.Instance.timeRate *= 6f;
                    StartCoroutine(Timer());
                }
                else if (otherTimer)
                {
                    TimeManager.Instance.timeRate /= 6f;
                    otherTimer = false;
                    RotateState();
                }
            }

            if (isEngineOrMotors)
            {
                TimeManager.Instance.motorsOff = false;
            }

            //wind particles code

            if (!TimeManager.Instance.motorsOff && isEngineOrMotors)
            {
                Object1.SetActive(true);
                Object2.SetActive(true);
                Object3.SetActive(true);
            }


        }

        if (state == ApplianceState.OFF)
        {
            ResourceManager.electricity -= kwMOff;

            if (isEngineOrMotors)
            {
                TimeManager.Instance.motorsOff = true;
                Object1.SetActive(false);
            }
        }

        if (state == ApplianceState.UNPLUGGED)
        {
            if (isEngineOrMotors)
            {
                TimeManager.Instance.motorsOff = true;
                Object1.SetActive(false);
            }
        }
    }

    public void RotateState()
    {
        switch (state)
        {
            case ApplianceState.OFF:
                state = ApplianceState.ON;
                break;
            case ApplianceState.ON:
                state = ApplianceState.UNPLUGGED;
                break;
            case ApplianceState.UNPLUGGED:
                state = ApplianceState.OFF;
                break;
        }
        SetMat();
    }

    private void SetMat()
    {
        MeshRenderer renderer = GetComponent<MeshRenderer>();

        if (renderer == null)
            renderer = GetComponentInChildren<MeshRenderer>();

        if (renderer == null)
            throw new Exception();


        //A switch case is basically just and else-if statement BUT it's more performant!
        switch (state)
        {
            case ApplianceState.OFF:
                renderer.material = offMat;
                break;
            case ApplianceState.ON:
                renderer.material = onMat;
                break;
            case ApplianceState.UNPLUGGED:
                renderer.material = unplugMat;
                break;
        }
    }

    IEnumerator Timer()
    {
        timer = true;
        yield return new WaitForSeconds(amountOfSecondsDoingTask);
        otherTimer = true;
        timer = false;

    }

    //Ok sometimes this gameobject spawns earlier than the Instance so put it in a while loop until it finds the instance
    IEnumerator SearchForInstance()
    {
        while (TimeManager.Instance == null)
        {
            //If you remove this line of code Unity crashes by the way :D
            yield return null;
        }
        //Subscribe to the minutePassed event
        TimeManager.Instance.minutePassed += DeductElectricity;
        yield return null;
    }


}
