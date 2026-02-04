using UnityEngine;

public class TestBet : MonoBehaviour
{
    public int betAmount;
    public BetType betType;
    public int number;
    public RoulettePocket.PocketColor color;

    public Bet bet;

    private void Awake()
    {
        bet = new Bet(betAmount, betType)
        {
            number = number,
            color = color
        };
    }

    public void PlaceBet()
    {
        BetManager.Instance.PlaceBet(bet);
    }
}
