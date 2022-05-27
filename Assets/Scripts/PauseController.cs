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
            MenuManager.OpenMenu(Menu.PAUSE_SCREEN, MenuManager.CheckMenu());
        }
        else
        {
        }

        GameStateManager.Instance.SetState(newGameState);
    }
}
