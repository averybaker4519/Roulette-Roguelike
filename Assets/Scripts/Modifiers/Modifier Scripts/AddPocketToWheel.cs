using UnityEngine;

[CreateAssetMenu(menuName = "Upgrades/One Time Modifier/Wheel Modifier/Add Pocket to Wheel")]
[System.Serializable]
public class AddPocketToWheel : Modifier
{
    [HideInInspector] public int numberOfPocketsToAdd = 1;
    [HideInInspector] public RoulettePocket pocketToAdd;


    
    public override IGameModifiers CreateModifier()
    {
        return new IAddPocketModifier(pocketToAdd, numberOfPocketsToAdd);
    }

    
    private class IAddPocketModifier : ISpinModifier
    {
        private readonly RoulettePocket pocket;
        private readonly int amount;

        public IAddPocketModifier(RoulettePocket redPocket, int amount)
        {
            this.pocket = redPocket;
            this.amount = amount;
        }

        public void ApplyModifier(SpinContext context, RouletteWheel wheel)
        {
            for (int i = 0; i < amount; i++)
            {
                context.pockets.Add(pocket);
                wheel.AddNewPocket(pocket);
            }
        }
    }
}
