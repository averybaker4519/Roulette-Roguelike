using UnityEngine;

public class AddRed100Pocket : MonoBehaviour, ISpinModifier
{
    public void ApplyModifier(SpinContext context)
    {
        var newPocket = new RoulettePocket(100, RoulettePocket.PocketColor.RED, 35f);
        context.pockets.Add(newPocket);
    }
}
