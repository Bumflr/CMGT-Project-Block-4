using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Honestly an enum is just an array of indexes, but with a name assigned to it so its a bit more readable.
public enum ApplianceState
{
    ON,
    OFF,
    NO_POWER
}

public enum Uses
{
    StoreFood,
    CookFood,
    FryFood,
    WashHands,
    WashDishes,
    MoveShip,
    Entertain,
    DryClothes,
    HeatWater,
    WashClothes,
    FixElectricity
}

public class ApplianceScript : MonoBehaviour
{
    private ResourceManager ResourceManager;
    [HideInInspector] public ApplianceManager applianceManager;
    [HideInInspector] public int index;
    public float kwH;
    public Uses use;
    //wind objects
    /*public GameObject Object1;
    public GameObject Object2;
    public GameObject Object3;*/

    /*public bool isManualAppliance;
    public bool isEngineOrMotors;*/
    public delegate void TaskEventHandler(Uses uses);
    public event TaskEventHandler TaskCompleted;

    public ApplianceState state;

    public Rigidbody rb;

    public void Begin()
    {
        ResourceManager = FindObjectOfType<ResourceManager>();

        state = ApplianceState.OFF;
        SetSymbol();
        //Is like a just calling a function but a bit different
        StartCoroutine(SearchForInstance());
    }

    //This currently does nothing
    public void OnClick()
    {
        /*if (isManualAppliance)
        {
            if (timer == false && !otherTimer)
            {
                TimeManager.Instance.timeRate *= 6f;
                //StartCoroutine(Timer());
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
        }*/

        //wind particles code

        /*if (!TimeManager.Instance.motorsOff && isEngineOrMotors)
{
    Object1.SetActive(true);
    Object2.SetActive(true);
    Object3.SetActive(true);
}*/
        /*if (state == ApplianceState.OFF)
        {
            if (isEngineOrMotors)
            {
                TimeManager.Instance.motorsOff = true;
                //Object1.SetActive(false);
            }
        }*/

        /*if (state == ApplianceState.NO_POWER)
        {
            if (isEngineOrMotors)
            {
                TimeManager.Instance.motorsOff = true;
                //Object1.SetActive(false);
            }
        }*/
    }


    private void DoingTask()
    {
        //blahblah
        //Add a small timer her-o which shows that stuff
        TaskCompleted?.Invoke(use);
    }


    private void DeductElectricity(object sender, EventArgs e)
    {
        //kilo watt minute
        //float kwM = kwH /  60;

        if (state == ApplianceState.ON)
        {
            ResourceManager.electricity -= kwH;
            DoingTask();
            //if it is an appliance that requires work to use, it fastforwards time
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
                state = ApplianceState.OFF;
                break;
            case ApplianceState.NO_POWER:
                state = ApplianceState.OFF;
                break;
        }

        SetSymbol();
    }

    private void SetSymbol() { applianceManager.SetSymbol(state, index); }


    //Ok sometimes this gameobject spawns earlier than the Instance so put it in a while loop until it finds the instance
    IEnumerator SearchForInstance()
    {
        while (TimeManager.Instance == null)
        {
            //If you remove this line of code Unity crashes by the way :D
            yield return null;
        }
        //Subscribe to the minutePassed event
        TimeManager.Instance.HourPassed += DeductElectricity;
        yield return null;
    }


}
