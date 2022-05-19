using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{
    public Text electricityText;

    public float electricity;

    // Start is called before the first frame update
    void Awake()
    {
        electricity = 100;
    }

    private void Update()
    {
        electricityText.text = electricity.ToString("F2") + " kwH";
    }


}
