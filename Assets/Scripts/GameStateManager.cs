public class GameStateManager
{
    //This script holds the current game state, not really necessary to change tbh
    private static GameStateManager _instance;
    public static GameStateManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = new GameStateManager();

            return _instance;
        }
    }

    public GameState CurrentGameState { get; private set; }

    public delegate void GameStateChangeHandler(GameState newGameState);
    public event GameStateChangeHandler OnGameStateChanged;

    private GameStateManager()
    {

    }

    public void SetState(GameState newGameState)
    {
        if (newGameState == CurrentGameState)
            return;

        CurrentGameState = newGameState;
        OnGameStateChanged?.Invoke(newGameState);
    }
}

//These are all of the game states
public enum GameState
{
    Gameplay,
    Paused,
    UpgradingAndPlacing,
    EndOfDay,
    GameOver,
    Cutscene,
    Loading
}


