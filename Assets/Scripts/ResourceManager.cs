using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{
    //Holds all of the resources as well as the UI 

    public static ResourceManager Instance;
    public Text electricityText;
    public Text scrapText;

    public float electricity;
    public float scrap;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;

        electricity = 100;
        scrap = 0;
    }

    private void Update()
    {
        electricityText.text = electricity.ToString("F2") + " kwH";
        scrapText.text = scrap.ToString("F0");
    }


}
