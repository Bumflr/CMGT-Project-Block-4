using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //This script holds all of the managers to interlock with each other if needed.
    //HAHAHAH CUTE

    public static GameManager Instance;

    public ApplianceManager am;
    public ResourceManager rm;
    public TimeManager tm;
    public EfficiencyManager em;
    public EndOfDayResultsScript eodr;

    private void Awake()
    {
        Instance = this;

        am.gm = Instance;
        rm.gm = Instance;
        
    }

    void Update()
    {

    }

  
    /*IEnumerator SearchForTimeInstance(GameObject )
    {
        desiredScript.GetType();

        if (desiredScript is TimeManager)
        {
            while (TimeManager.Instance == null)
            {
                yield return null;

                
            }
        }
        else if (desiredScript is ResourceManager)
        {
            while (ResourceManager.Instance == null)
            {
                yield return null;

            }
        }

        yield return null;

        /*while (TimeManager.Instance == null)
        {
            //If you remove this line of code Unity crashes by the way :D
            yield return null;
        }*/
        //Subscribe to the minutePassed event
        //TimeManager.Instance.HourPassed += DeductElectricity;
        //yield return null;

    //}


}
