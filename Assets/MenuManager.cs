using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI;

    public static bool IsInitialised { get; private set; }

    public static GameObject pauseMenu, settingsMenu, gameOverMenu;/*, defaultPause, defaultOptions, defaultGameOver;*/

    public static GameObject currentlyOn;

    public static MenuControls menuControls;


    private void Awake()
    {
        GameStateManager.Instance.OnGameStateChanged += OnGameStateChanged;
        menuControls = GetComponent<MenuControls>();
        IsInitialised = false;
    }

    private void OnDestroy()
    {
        GameStateManager.Instance.OnGameStateChanged -= OnGameStateChanged;
    }

    private void OnGameStateChanged(GameState newGameState)
    {
        switch (newGameState)
        {
            case GameState.Gameplay:
                pauseMenuUI.SetActive(false);
                break;
            case GameState.Paused:
                if (!IsInitialised)
                    Init();

                currentlyOn = pauseMenu;

                pauseMenuUI.SetActive(true);
                //menuControls.SetFirstButton(defaultPause);
                break;
            case GameState.GameOver:

                if (!IsInitialised)
                    Init();

                currentlyOn = gameOverMenu;
                gameOverMenu.SetActive(true);
                //menuControls.SetFirstButton(defaultGameOver);

                break;
        }
    }

    public static void Init()
    {
        //If you want to add another screen to the menus, add a canvas with all the shit in it as well as a deafultbutton and initiliaze dat shit over here
        GameObject canvas = GameObject.Find("UI_MANAGER");

        pauseMenu = canvas.transform.Find("PauseMenu").gameObject;
        settingsMenu = canvas.transform.Find("SettingsMenu").gameObject;
        /*gameOverMenu = canvas.transform.Find("GameOverMenu").gameObject;*/

        /*defaultPause = pauseMenu.transform.Find("Panel").gameObject.transform.Find("defaultButton").gameObject;
        defaultOptions = settingsMenu.transform.Find("Panel").gameObject.transform.Find("defaultButton").gameObject;
        defaultGameOver = gameOverMenu.transform.Find("Panel").gameObject.transform.Find("defaultButton").gameObject;*/

        IsInitialised = true;
    }

    public static void OpenMenu(Menu menu, GameObject callingMenu)
    {
        //this code is used when OpenMenu gets called if something happens and the player didn't trigger it via pressing pause
        if (!IsInitialised)
            Init();

        switch (menu)
        {
            case Menu.PAUSE_SCREEN:
                currentlyOn = pauseMenu;
                pauseMenu.SetActive(true);
                //menuControls.SetFirstButton(defaultPause);
                break;
            case Menu.SETTINGS:
                currentlyOn = settingsMenu;
                settingsMenu.SetActive(true);
                //menuControls.SetFirstButton(defaultOptions);
                break;
        }

        callingMenu.SetActive(false);
    }

    public static GameObject CheckMenu()
    {
        return currentlyOn;
    }

   /* public void ActivateMenu()
    {
        //AudioListener.pause = true;
    }
    public void DeactiveMenu()
    {
        //AudioListener.pause = false;
    }*/


}

