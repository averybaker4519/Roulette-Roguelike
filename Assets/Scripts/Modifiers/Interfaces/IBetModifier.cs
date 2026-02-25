using UnityEngine;

public interface IBetModifier : IGameModifiers
{
    public void ApplyModifier(Bet bet, RouletteWheel hookedWheel, RoulettePocket pocket, ref bool isWin, ref float payoutMultiplier);
}
