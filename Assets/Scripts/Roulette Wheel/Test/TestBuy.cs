using UnityEngine;
using static RoulettePocket;

public class TestBuy : MonoBehaviour
{
    [SerializeField] private AddPocket upgrade;
    [SerializeField] private Wheel wheelDefinition;

    public void AddUpgrade()
    {
        if (RunManager.Instance == null) return;

        RoulettePocket redPocket = new RoulettePocket(100, RoulettePocket.PocketColor.RED);

        if (redPocket == null) return;

        ISpinModifier modifier = upgrade.CreateModifier(redPocket);
        RunManager.Instance.AddModifier(modifier);
    }
}
