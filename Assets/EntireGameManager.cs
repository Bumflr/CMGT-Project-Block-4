using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntireGameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void New_Game()
    {

    }

    public void Load_Game()
    {

    }

    public void Exit_Game()
    {
        Application.Quit();
    }

    public void Settings()
    {

    }
}
