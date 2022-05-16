using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{
    public Text electricityText;
    public Text hydrogenText;

    public float electricity;
    public float hydrogen;

    [SerializeField]
    public float hydrogenperMinute;

    // Start is called before the first frame update
    void Awake()
    {
        electricity = 100;
        hydrogen = 50;
        TimeManager.Instance.minutePassed += DeductHydrogen;
    }

    private void DeductHydrogen(object sender, EventArgs e)
    {
        hydrogen -= hydrogenperMinute;
    }

    private void Update()
    {
        electricityText.text = electricity.ToString("F2") + " kwH";
        hydrogenText.text = hydrogen.ToString("F2") + " H1";
    }


}
