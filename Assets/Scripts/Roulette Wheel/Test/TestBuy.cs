using UnityEngine;

public class TestBuy : MonoBehaviour
{
    public AddRed100Pocket addRed100PocketPrefab;

    public void AddUpgrade()
    {
        var go = new GameObject("AddRed100Pocket (runtime)");
        AddRed100Pocket instance = go.AddComponent<AddRed100Pocket>();

        RunManager.Instance?.AddModifier(instance);
    }
}
