using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntireGameManager : MonoBehaviour
{
    public EntireGameManager Instance;

    public bool skipTutorial;
    public float volume;
    //public bool enableVFX;

    public GameObject settingsMenu;
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }

        Instance = this;

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

    public void SetVolume(float value)
    {
        volume = value;
    }
    public void SetTooterool(bool value)
    {
        skipTutorial = value;
    }

   /* public void SetVolume(bool value)
    {
        enableVFX = value;
    }*/

    public void Settings()
    {
        settingsMenu.SetActive(true);
    }

}
