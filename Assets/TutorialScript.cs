using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    EntireGameManager engm;

    public GameObject tooterool;
    public GameObject Plane;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        engm = GameObject.Find("EntireGameManager").GetComponent<EntireGameManager>();

        if (engm.skipTutorial)
        {
            tooterool.SetActive(false);
            Plane.SetActive(false);
            player.SetActive(true); 
        }
        else
        {
            tooterool.SetActive(true);
            Plane.SetActive(true);
        }
    }

}
