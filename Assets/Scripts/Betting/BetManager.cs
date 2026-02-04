using System.Collections.Generic;
using UnityEngine;

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

    #region Betting

    private readonly List<Bet> activeBets = new List<Bet>();
    private RouletteWheel wheel;

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
            Destroy(this);
        }
    }

    #endregion


    #region Betting Functions
    
    public void PlaceBet(Bet bet)
    {
        if (bet == null)
        {
            Debug.LogWarning("BetManager: PlaceBet called with null bet.");
            return;
        }

        if (RunManager.Instance.HasEnoughChips(bet.betAmount))
        {
            RunManager.Instance.RemoveChips(bet.betAmount);
            activeBets.Add(bet);
        }
        else
        {
            Debug.LogWarning("BetManager: Not enough chips to place bet.");
            return;
        }
    }

    public void RemoveBet(Bet bet)
    {
        if (bet == null)
        {
            Debug.LogWarning("BetManager: RemoveBet called with null bet.");
            return;
        }

        if (!activeBets.Contains(bet))
        {
            Debug.LogWarning("BetManager: Attempted to remove a bet that is not active.");
            return;
        }

        if (activeBets.Remove(bet))
        {
             RunManager.Instance.AddChips(bet.betAmount);
        }
    }

    public void ClearAllBets(bool refundBets = false)
    {
        if (refundBets)
        {
            foreach (Bet bet in activeBets)
            {
                RunManager.Instance.AddChips(bet.betAmount);
            }
        }
        activeBets.Clear();
    }

    #endregion


    #region Wheel Hookup & Resolution

    private void HookToCurrentWheel()
    {
        if (RunManager.Instance == null) return;

        var wheel = RunManager.Instance.currentWheel;
        if (wheel != null)
        {
            // ensures no duplicate subscription
            wheel.OnSpinResolved -= HandleSpinResolved;
            wheel.OnSpinResolved += HandleSpinResolved;
        }
    }

    private void HandleSpinResolved(RoulettePocket pocket)
    {
        ResolveAllBets(pocket);
    }

    private void ResolveAllBets(RoulettePocket pocket)
    {
        if (activeBets == null || activeBets.Count == 0) return;
        List<Bet> betsToResolve = new List<Bet>(activeBets);
        activeBets.Clear();

        foreach (Bet bet in betsToResolve)
        {
            ResolveBet(pocket, bet);
        }
    }

    public void ResolveBet(RoulettePocket pocket, Bet bet)
    {
        bool isWin = bet.IsWin(pocket);
        float payout = bet.GetCurrentPayout();
        float payoutMultiplier = 1f;

        // apply modifiers
        foreach (var mod in RunManager.Instance.activeModifiers)
        {
            if (mod is IBetModifier betMod)
            {
                betMod.ApplyModifier(bet, wheel, pocket, ref isWin, ref payoutMultiplier);
            }
        }

        // payout
        if (bet.IsWin(pocket))
        {
            float totalReturn = bet.betAmount * (payout + 1f) * payoutMultiplier;
            int winnings = Mathf.RoundToInt(totalReturn);
            RunManager.Instance.AddChips(winnings);
            Debug.Log($"Bet won! Payout: {winnings} chips.");
        }
        else
        {
            Debug.Log("Bet lost");
        }
    }

    #endregion


    #region Built-in functions

    private void Awake()
    {
        HandleBetManagerInstance();
    }

    private void Start()
    {
        HookToCurrentWheel();
    }

    private void OnDestroy()
    {
        if (wheel != null)
        {
            wheel.OnSpinResolved -= HandleSpinResolved;
        }
    }

    #endregion
}
