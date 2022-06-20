using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainAudio : MonoBehaviour
{
    EntireGameManager engm;

    //public AudioListener ad;
    // Start is called before the first frame update
    void Start()
    {
        engm = GameObject.Find("EntireGameManager").GetComponent<EntireGameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        AudioListener.volume = engm.volume;
    }
}
