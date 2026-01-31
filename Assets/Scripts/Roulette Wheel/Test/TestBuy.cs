using UnityEngine;
using static RoulettePocket;

public class TestBuy : MonoBehaviour
{
    [SerializeField] private AddPocketOnSpin spinModifierUpgrade;
    [SerializeField] private AddPocket wheelModifierUpgrade;
    [SerializeField] private Wheel wheelDefinition;

    public void AddPocketOnSpinUpgrade()
    {
        if (RunManager.Instance == null) return;

        RoulettePocket redPocket = new RoulettePocket(100, RoulettePocket.PocketColor.RED);

        if (redPocket == null) return;

        ISpinModifier modifier = spinModifierUpgrade.CreateModifier(redPocket);
        RunManager.Instance.AddModifier(modifier);
    }

    public void AddPocketOnPurchaseUpgrade()
    {
        IWheelModifier modifier = wheelModifierUpgrade.CreateModifier();
        modifier.ApplyModifier(RunManager.Instance.currentWheel);
    }
}
