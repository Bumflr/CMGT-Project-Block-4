using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntireGameManager : MonoBehaviour
{
    public void New_Game()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit_Game()
    {
        Application.Quit();
    }

    public void Settings()
    {

    }
}
