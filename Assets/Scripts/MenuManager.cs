using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Menu
{
    PAUSE_SCREEN,
    SETTINGS,
    TASKS,
    UPGRADES
}

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI;

    public static bool IsInitialised { get; private set; }

    public static GameObject pauseMenu, settingsMenu, gameOverMenu;
    public static GameObject currentlyOn;


    private void Awake()
    {
        GameStateManager.Instance.OnGameStateChanged += OnGameStateChanged;
        IsInitialised = false;
    }

    private void OnDestroy()
    {
        GameStateManager.Instance.OnGameStateChanged -= OnGameStateChanged;
    }

    private void OnGameStateChanged(GameState newGameState)
    {
        if (!IsInitialised)
            Init();

        switch (newGameState)
        {
            case GameState.Gameplay:
                pauseMenuUI.SetActive(false);

                break;
            case GameState.Paused:

                currentlyOn = pauseMenu;
                pauseMenuUI.SetActive(true);

                break;
            case GameState.GameOver:

                currentlyOn = gameOverMenu;
                gameOverMenu.SetActive(true);

                break;
            case GameState.EndOfDay:
                break;
        }
    }

    public static void Init()
    {
        //ok so the GameObject.Find function is kinda horribly expensive lol. will change it out soon 
        //Especiially when searching using strings 
        GameObject canvas = GameObject.Find("UI_MANAGER");

        pauseMenu = canvas.transform.Find("PauseMenu").gameObject;
        settingsMenu = canvas.transform.Find("SettingsMenu(DEBUG)").gameObject;

        IsInitialised = true;
    }

    //Function which can be used to open menus
    //It takes the menu it wants to open as well as the menu it is being called from which it closes
    public static void OpenMenu(Menu menu, GameObject callingMenu)
    {
        if (!IsInitialised)
            Init();

        switch (menu)
        {
            case Menu.PAUSE_SCREEN:
                currentlyOn = pauseMenu;
                pauseMenu.SetActive(true);
                break;
            case Menu.SETTINGS:
                currentlyOn = settingsMenu;
                settingsMenu.SetActive(true);
                break;
        }

        callingMenu.SetActive(false);
    }

    public static GameObject CheckMenu()
    {
        return currentlyOn;
    }
}


