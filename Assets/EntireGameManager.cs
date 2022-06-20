using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntireGameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this);
    }

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
