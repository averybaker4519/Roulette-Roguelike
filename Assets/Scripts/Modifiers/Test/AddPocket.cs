using UnityEngine;

[CreateAssetMenu(menuName = "Upgrades/Test/Add Pocket TEST")]

public class AddPocket : ScriptableObject
{
    [Header("Upgrade Data")]
    public int amount = 1;
    public RoulettePocket pocket; 

    public IWheelModifier CreateModifier()
    {
        return new IAddPocketModifier(pocket, amount);
    }

    private class IAddPocketModifier : IWheelModifier
    {
        private readonly RoulettePocket redPocket;
        private readonly int amount;

        public IAddPocketModifier(RoulettePocket pocket, int amount)
        {
            this.redPocket = pocket;
            this.amount = amount;
        }

        public void ApplyModifier(RouletteWheel wheel)
        {
            for (int i = 0; i < amount; i++)
            {
                Debug.Log(wheel);
                
                wheel.AddNewPocket(redPocket);
            }
        }
    }
}
