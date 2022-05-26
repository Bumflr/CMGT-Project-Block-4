using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public ResourceManager resourceManager;
    public WeatherManager weatherManager;

    public bool interactedWith = false;
    // Update is called once per frame
    public static GameManager Instance;
    private RaycastHit savedHit;

    public Vector2 offset;
    public RectTransform popUpPrefab;
    private Vector2 uiOffset;
    //The canvas the popup is n
    public RectTransform CanvasRect;


    public float maxTime;

    private void Awake()
    {
        Instance = this;
        uiOffset = new Vector2((float)CanvasRect.sizeDelta.x / 2f, (float)CanvasRect.sizeDelta.y / 2f);
    }

    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        { 

            if (savedHit.transform != hit.transform)
            {
                popUpPrefab.GetComponent<PopUpPanel>().SetAlpha(0);
                savedHit = hit;
                interactedWith = false;
            }
            else
            {

                if (interactedWith)
                {
                    popUpPrefab.GetComponent<PopUpPanel>().SetAlphaSmooth(new Color(1, 1, 1, 1));
                }
                else
                {
                    popUpPrefab.GetComponent<PopUpPanel>().SetAlpha(0);

                    Vector2 ViewportPosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);

                    Vector2 proportionalPosition = new Vector2(ViewportPosition.x * CanvasRect.sizeDelta.x, ViewportPosition.y * CanvasRect.sizeDelta.y);

                    // Set the position and remove the screen offset
                    popUpPrefab.localPosition = proportionalPosition + offset - uiOffset;
                }
            }

            if (Input.GetMouseButtonDown(1))
            {
                if (hit.transform.tag == "Appliance")
                {
                    popUpPrefab.GetComponent<PopUpPanel>().SetData(hit.transform.name, hit.transform.gameObject.GetComponent<ApplianceScript>().kwH, true);
                    interactedWith = !interactedWith;
                }
                else
                    interactedWith = false;
            }

            if (Input.GetMouseButtonDown(0))
            {
                if (hit.transform.tag == "Appliance")
                {
                    hit.transform.GetComponent<ApplianceScript>().RotateState();
                    return;
                }
            }
        }
        else
        {
            interactedWith = false;
            popUpPrefab.GetComponent<PopUpPanel>().SetAlpha(0);
        }
    }


}
