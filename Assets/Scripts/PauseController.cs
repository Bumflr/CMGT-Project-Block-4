using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    public GameState currentGameState;

    private void Awake()
    {
        GameState currentGameState = GameStateManager.Instance.CurrentGameState;

        GameState newGameState = GameState.Gameplay;

        GameStateManager.Instance.SetState(newGameState);
    }

    public static void Pausing()
    {
        Debug.Log(MenuManager.currentlyOn);

        GameState currentGameState = GameStateManager.Instance.CurrentGameState;

        GameState newGameState = currentGameState == GameState.Gameplay ? GameState.Paused : GameState.Gameplay;

        if (newGameState == GameState.Paused)
        {
            Time.timeScale = 0;
            MenuManager.OpenMenu(Menu.PAUSE_SCREEN, MenuManager.CheckMenu());
        }
        else
        {
            Time.timeScale = 1;

        }

        GameStateManager.Instance.SetState(newGameState);
    }
}
