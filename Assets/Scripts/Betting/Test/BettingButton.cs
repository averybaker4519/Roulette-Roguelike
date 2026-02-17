using System;
using UnityEngine;
using static RoulettePocket;

public class BettingButton : MonoBehaviour
{
    [Header("Universal Betting Info")]
    public int betAmount;
    public BetType betType;

    [Header("Number Bet Info")]
    public int number; // For Straight Up bets
    public RoulettePocket.PocketColor color; // For Color bets
    public int dozen; // For Dozen bets (1, 2, or 3)
    public int column; // For Column bets (1, 2, or 3)
    public bool high; // For High/Low bets (true for High, false for Low)
    public bool even; // For Even/Odd bets (true for Even, false for Odd)

    public Bet bet;

    public BettingTable parentBettingTable;



    public void PlaceBet()
    {
        betAmount = (int)FindFirstObjectByType<UnityEngine.UI.Slider>().value;

        bet = new Bet(betAmount, betType);

        switch (betType)
        {
            case BetType.Straight:
                bet.number = number;
                break;
            case BetType.RedBlack:
                bet.color = color;
                break;
            case BetType.Dozen:
                bet.dozen = dozen;
                break;
            case BetType.Column:
                bet.column = column;
                break;
            case BetType.LowHigh:
                bet.high = high;
                break;
            case BetType.EvenOdd:
                bet.even = even;
                break;
        }

        BetManager.Instance.PlaceBet(bet);
        parentBettingTable.UpdateUI();
    }
}
