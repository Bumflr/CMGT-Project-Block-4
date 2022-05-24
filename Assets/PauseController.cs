using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    public GameState bruh;

    private void Awake()
    {
        GameState currentGameState = GameStateManager.Instance.CurrentGameState;

        GameState newGameState = GameState.Gameplay;

        GameStateManager.Instance.SetState(newGameState);
    }
    // Update is called once per frame
    void Update()
    {
        bruh = GameStateManager.Instance.CurrentGameState;

        if (Input.GetButtonDown("Pause"))
        {
            //This needs to be chaaaanged lolololol like but also in my own game tbh BUT it works so who gives a poop.

            GameState currentGameState = GameStateManager.Instance.CurrentGameState;

            switch (currentGameState)
            {
                case GameState.Gameplay:
                    break;
                case GameState.Paused:

                    if (MenuManager.CheckMenu() == MenuManager.pauseMenu)
                    {
                        Debug.Log(MenuManager.CheckMenu());
                        //break breaks it out of this contained area so the rest of the code continues
                        break;
                    }
                    else
                    {
                        Debug.Log(MenuManager.CheckMenu());
                        //return returns the code aaaalll the way back so the code underneath doesn't get called
                        //which i do not fuckign understand but whateeeever
                        MenuManager.OpenMenu(Menu.PAUSE_SCREEN, MenuManager.CheckMenu());
                        return;
                    }
                default:
                    return;
            }

            GameState newGameState = currentGameState == GameState.Gameplay
                ? GameState.Paused
                : GameState.Gameplay;

            GameStateManager.Instance.SetState(newGameState);

        }
    }

    public static void Resume()
    {
        Debug.Log(MenuManager.currentlyOn);

        GameState currentGameState = GameStateManager.Instance.CurrentGameState;

        GameState newGameState = currentGameState == GameState.Gameplay
               ? GameState.Paused
               : GameState.Gameplay;

        GameStateManager.Instance.SetState(newGameState);
    }
}
