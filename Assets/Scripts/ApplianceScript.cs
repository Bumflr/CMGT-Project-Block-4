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
   
    Hunger,
    Cleanliness,
    Boredom,
    GeneratePower,
    Engine
}

public class ApplianceScript : MonoBehaviour
{
    [HideInInspector] public ApplianceManager applianceManager;
    [HideInInspector] public int index;

    public float[] kwH;
    public float gains;
    public Uses use;

    public float health = 100;
    public int level = 0;


    public ResourceManager rm;
    //wind objects
    /*public GameObject Object1;
    public GameObject Object2;
    public GameObject Object3;*/

    /*public bool isManualAppliance;
    public bool isEngineOrMotors;*/


    public delegate void PoopEventHandler(ApplianceScript ass);
    public event PoopEventHandler IsOn;
    public event PoopEventHandler IsOff;

    public ApplianceState state;

    public void Begin()
    {
        state = ApplianceState.OFF;
        SetSymbol();
        //Is like a just calling a function but a bit different
        //StartCoroutine(SearchForInstance());
    }

    //This currently does nothing
    //I'll also add the wind effects back later
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

    public void RotateState()
    {
        switch (state)
        {
            case ApplianceState.OFF:
                state = ApplianceState.ON;
                IsOn?.Invoke(this);
                break;
            case ApplianceState.ON:
                state = ApplianceState.OFF;
                IsOff?.Invoke(this);
                break;

            case ApplianceState.NO_POWER:
                IsOff?.Invoke(this);
                break;
        }

        SetSymbol();
    }

    public void UpgradeState()
    {
        if (rm.scrap > 0)
        {
            level++;
            rm.scrap--;
        }
    }

    public void FixAppliance()
    {
        if (rm.scrap > 0)
        {
            health = 100;
            rm.scrap--;

            state = ApplianceState.OFF;
            IsOff?.Invoke(this);

            applianceManager.ResetSlider(index);

            SetSymbol();
        }
    }

    public void SetSymbol() { applianceManager.SetSymbol(state, index); }


    //Ok sometimes this gameobject spawns earlier than the Instance so put it in a while loop until it finds the instance
    IEnumerator SearchForInstance(object desiredScript)
    {
        while (TimeManager.Instance == null)
        {
            //If you remove this line of code Unity crashes by the way :D
            yield return null;
        }
        //Subscribe to the minutePassed event
        //TimeManager.Instance.HourPassed += DeductElectricity;
        yield return null;
    }


}
