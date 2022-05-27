using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //This script holds all of the managers to interlock with each other if needed.

    public ResourceManager resourceManager;
    public WeatherManager weatherManager;

    // Update is called once per frame
    public static GameManager Instance;

    public FailScreen failScreen;

    public float maxTime;

    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        /*if (resourceManager.electricity <= 0)
        {
            failScreen.setup();
        }*/
    }
}
