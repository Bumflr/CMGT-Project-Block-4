using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControls : MonoBehaviour
{
    //This script holds all of the functions we should give to the buttons.
    //I dont know why 2021 Daniel decided to put all of these functions in one single script instead of just giving every button it's own small script but whatever ig.

    private void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            Debug.Log("what");
            PauseController.Pausing();
        }
    }

    public void OnClick_Resume()
    {
        PauseController.Pausing();
    }

    public void OnClick_Options()
    {
        MenuManager.OpenMenu(Menu.SETTINGS, MenuManager.CheckMenu());
    }

    public void OnClick_Upgrades()
    {
       
    }

    public void OnClick_Tasks()
    {
        //MenuManager.OpenMenu(Menu., MenuManager.CheckMenu());
    }

    public void OnClick_Saving()
    {

    }

    public void OnClick_Loading()
    {

    }

    public void OnClick_Efficiency()
    {

    }

    public void OnClick_EndOfDayResume()
    {

    }

}
