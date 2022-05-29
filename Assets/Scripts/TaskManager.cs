using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public Task[] tasks;
    public UiTask[] uiTasks;
    public GameObject taskPrefab;
    public float dangerPercentage;

    public float yOffset;

    //Manager which holds all of the Tasks 
    // Start is called before the first frame update
    void Start()
    {
        uiTasks = new UiTask[tasks.Length];

        for (int i = 0; i < tasks.Length; i++)
        {
            var t = Instantiate(taskPrefab, gameObject.transform.position, taskPrefab.transform.rotation, this.transform);

            t.gameObject.transform.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
            t.gameObject.transform.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -50 + -i * yOffset);

            uiTasks[i] = t.gameObject.transform.GetComponent<UiTask>();

            tasks[i].currentStep = 0;
            uiTasks[i].SetData(tasks[i].title, tasks[i].amountOfDays, dangerPercentage, tasks[i].stepsToFinish[tasks[i].currentStep]);
        }

        StartCoroutine(SearchForInstance());
    }

    public void DayPassed(object sender, EventArgs e)
    {
        for (int i = 0; i < tasks.Length; i++)
        {
            uiTasks[i].DayPassed();
        }
    }

    public void TaskCompleted(Uses use)
    {
        for (int i = 0; i < tasks.Length; i++)
        {
            if (tasks[i].stepsToFinish.Length == 0)
            {
                throw new System.Exception( tasks[i].name + " Step To Finish Not set!");
            }
            else
            {
                if (use == tasks[i].stepsToFinish[tasks[i].currentStep])
                {
                    if (tasks[i].currentStep + 1 < tasks[i].stepsToFinish.Length)
                    {
                        tasks[i].currentStep++;

                        uiTasks[i].SetNextStep(tasks[i].stepsToFinish[tasks[i].currentStep]);

                        Debug.Log(tasks[i].stepsToFinish[tasks[i].currentStep]);
                    }
                    else
                    {
                        uiTasks[i].SetCompletion();

                        tasks[i].currentStep = 0;
                        uiTasks[i].SetNextStep(tasks[i].stepsToFinish[tasks[i].currentStep]);

                        ResourceManager.Instance.scrap++;
                        Debug.Log("Task Complete!");
                        //TASK COMPLETE
                    }
                }
            }
        }
    }

    IEnumerator SearchForInstance()
    {
        while (TimeManager.Instance == null)
        {
            //If you remove this line of code Unity crashes by the way :D
            yield return null;
        }
        //Subscribe to the minutePassed event
        TimeManager.Instance.DayPassed += DayPassed;
        yield return null;
    }




}


