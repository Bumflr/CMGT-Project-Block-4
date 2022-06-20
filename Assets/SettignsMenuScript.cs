using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettignsMenuScript : MonoBehaviour
{
    EntireGameManager engm;

    public GameObject slider;
    public GameObject bool1;
   // public GameObject bool2;
    // Start is called before the first frame update
    void Start()
    {
        engm = GameObject.Find("EntireGameManager").GetComponent<EntireGameManager>();
        // Start is called before the first frame update

        slider.GetComponent<Slider>().onValueChanged.AddListener(delegate { engm.SetVolume(slider.GetComponent<Slider>().value); } );

        bool1.GetComponent<Toggle>().onValueChanged.AddListener(delegate { engm.SetTooterool(bool1.GetComponent<Toggle>().isOn); });

       // bool2.GetComponent<Toggle>().onValueChanged.AddListener(delegate { engm.SetVolume(bool2.GetComponent<Toggle>().isOn); });

    }
}
