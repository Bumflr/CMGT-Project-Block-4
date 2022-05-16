using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ResourceManager resourceManager;
    public WeatherManager weatherManager;

    public event EventHandler uiClose;
    // Update is called once per frame
    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.transform.name);

                if (hit.transform.tag == "Appliance")
                {
                    hit.transform.GetComponent<ApplianceScript>().RotateState();
                    return;
                }
            }
            //uiClose?.Invoke(this, EventArgs.Empty);
        }
    }


}
