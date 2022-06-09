using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Task")]
public class Task : ScriptableObject
{
    public string title;
    public int amountOfActions;

    public Uses[] stepsToFinish;
    public int currentStep;

}