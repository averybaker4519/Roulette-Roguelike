using System.Xml;
using UnityEngine;
using UnityEngine.Playables;

public class GameStateManager : MonoBehaviour
{
    // Variables
    #region Static vars

    private static GameStateManager Instance;
    private static GAMESTATE GameState;

    #endregion



    #region Enums

    public enum GAMESTATE
    {
        PLAYING,
        PAUSED,
        MENU,
        GAMEOVER
    }

    #endregion




    // Functions
    #region GameStateManager

    // makes script into singleton, called in Awake()
    public void HandleGameStateManagerInstance()
    {
        if (Instance == null)
        {
            Instance = this;
            GameState = GAMESTATE.MENU;
            DontDestroyOnLoad(Instance);
        }
        else
        {
            Destroy(this);
        }
    }

    #endregion



    #region GameState

    public static GAMESTATE GetGameState()
    {
        return GameState;
    }

    public static void SetGameState(GAMESTATE NewGameState)
    {
        GameState = NewGameState;
    }

    #endregion



    #region Changing Game States

    public static void MainMenu()
    {
        SetGameState(GAMESTATE.MENU);
    }

    public static void Play()
    {
        SetGameState(GAMESTATE.PLAYING);
        Time.timeScale = 1f;
    }

    public static void Pause()
    {
        SetGameState(GAMESTATE.PAUSED);
        Time.timeScale = 0f;
    }

    public static void GameOver()
    {
        SetGameState(GAMESTATE.GAMEOVER);
    }

    #endregion



    #region Built-in functions

    private void Awake()
    {
        HandleGameStateManagerInstance();
    }

    #endregion
}
 