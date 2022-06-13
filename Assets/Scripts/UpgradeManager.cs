using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class UpgradeManager : MonoBehaviour
{
    public bool upgradeModeOn;
    public GameObject filter;


    public void ButtonModeBaby()
    {
        upgradeModeOn = !upgradeModeOn;
        filter.GetComponent<Volume>().profile.TryGet(out ColorCurves c);
        c.active = !c.active;
    }
}
