using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FailScreen : MonoBehaviour
{
    public void setup()
    {
        gameObject.SetActive(true);
    }

    public void RestartButton() 
    {
        SceneManager.LoadScene("SampleScene");
    }
}
