using UnityEngine;

[CreateAssetMenu(menuName = "Upgrades/Test/Add Red Pocket On Spin TEST")]
public class AddPocketOnSpin : ScriptableObject
{
    [Header("Upgrade Data")]
    public int amount = 1;

    public ISpinModifier CreateModifier(RoulettePocket redPocket)
    {
        return new IAddPocketModifier(redPocket, amount);
    }


    private class IAddPocketModifier : ISpinModifier
    {
        private readonly RoulettePocket redPocket;
        private readonly int amount;

        public IAddPocketModifier(RoulettePocket redPocket, int amount)
        {
            this.redPocket = redPocket;
            this.amount = amount;
        }

        public void ApplyModifier(SpinContext context, RouletteWheel wheel)
        {
            for (int i = 0; i < amount; i++)
            {
                context.pockets.Add(redPocket);
                wheel.pockets.Add(redPocket);
            }
        }
    }
}
