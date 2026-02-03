using UnityEngine;

public class Bet
{
    // Variables
    [Header("Bet Info")]
    public BetType betType;
    public int betAmount;

    [Header("Data Depending on Bet Type")]
    public int number; // For Straight Up bets
    public RoulettePocket.PocketColor color; // For Color bets
    public int dozen; // For Dozen bets (1, 2, or 3)
    public int column; // For Column bets (1, 2, or 3)
    public bool high; // For High/Low bets (true for High, false for Low)
    public bool even; // For Even/Odd bets (true for Even, false for Odd)



    // Functions

    #region Constructor

    public Bet(int amount, BetType type)
    {
        betAmount = amount;
        betType = type;
    }

    #endregion

    #region Win Check

    public bool IsWin(RoulettePocket pocket)
    {
        switch(betType)
        {
            case BetType.Straight:
                return pocket.baseNumber == number;
            case BetType.RedBlack:
                return pocket.baseColor == color;
            case BetType.Dozen:
                if (pocket.baseColor == RoulettePocket.PocketColor.GREEN) return false;
                if (pocket.baseNumber <= 0) return false;
                if (dozen == 1)
                    return pocket.baseNumber >= 1 && pocket.baseNumber <= 12;
                else if (dozen == 2)
                    return pocket.baseNumber >= 13 && pocket.baseNumber <= 24;
                else // dozen == 3
                    return pocket.baseNumber >= 25 && pocket.baseNumber <= 36;
            case BetType.Column:
                if (pocket.baseColor == RoulettePocket.PocketColor.GREEN) return false;
                if (pocket.baseNumber <= 0) return false;
                if (column == 1)
                    return (pocket.baseNumber - 1) % 3 == 0;
                else if (column == 2)
                    return (pocket.baseNumber - 2) % 3 == 0;
                else // column == 3
                    return pocket.baseNumber % 3 == 0;
            case BetType.LowHigh:
                if (pocket.baseColor == RoulettePocket.PocketColor.GREEN) return false;
                if (pocket.baseNumber <= 0) return false;
                if (high)
                    return pocket.baseNumber >= 19 && pocket.baseNumber <= 36;
                else // low
                    return pocket.baseNumber >= 1 && pocket.baseNumber <= 18;
            case BetType.EvenOdd:
                if (pocket.baseColor == RoulettePocket.PocketColor.GREEN) return false;
                if (pocket.baseNumber <= 0) return false;
                if (even)
                    return pocket.baseNumber % 2 == 0;
                else // odd
                    return pocket.baseNumber % 2 != 0;
            default:
                Debug.LogError("Invalid Bet Type");
                return false;
        }
    }

    #endregion

    #region Base Payout Info

    public int GetBasePayout()
    {
        switch (betType)
        {
            case BetType.Straight: return 35;
            case BetType.RedBlack: return 1;
            case BetType.EvenOdd: return 1;
            case BetType.LowHigh: return 1;
            case BetType.Dozen: return 2;
            case BetType.Column: return 2;
            default: return 0;
        }
    }

    #endregion
}
