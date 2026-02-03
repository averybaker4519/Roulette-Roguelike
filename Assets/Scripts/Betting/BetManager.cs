using UnityEngine;
using static GameStateManager;

public class BetManager : MonoBehaviour
{
    // Variables
    #region Static vars

    public static BetManager Instance { get; private set; }

    #endregion

    #region Modifiable Payouts

    public float straightPayout = 35f;
    public float redBlackPayout = 1f;
    public float dozenPayout = 2f;
    public float columnPayout = 2f;
    public float lowHighPayout = 1f;
    public float evenOddPayout = 1f;

    #endregion



    // Functions
    #region BetManager Instance

    // makes script into singleton, called in Awake()
    public void HandleBetManagerInstance()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    #endregion



    #region Built-in functions

    private void Awake()
    {
        HandleBetManagerInstance();
    }

    #endregion
}
