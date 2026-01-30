using UnityEngine;

public class AddRed100Pocket : MonoBehaviour, ISpinModifier
{
    public void ApplyModifier(SpinContext context)
    {
        print("Adding Red 100 Pocket to the Roulette Wheel");
    }
}
