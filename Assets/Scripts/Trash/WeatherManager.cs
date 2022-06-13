using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeatherStates
{
    Sunny,
    Cloudy,
    Rain,
    Snow,
    Acid_Rain,
    Storm
}

public class WeatherManager : MonoBehaviour
{
    public WeatherStates currentState;

    void SetWeather(WeatherStates newState)
    {
        currentState = newState;
    }
}
