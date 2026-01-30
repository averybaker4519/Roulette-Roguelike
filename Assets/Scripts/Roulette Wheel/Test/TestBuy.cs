using UnityEngine;

public class TestBuy : MonoBehaviour
{
    public AddRed100Pocket addRed100PocketPrefab;

    public void AddUpgrade()
    {
        addRed100PocketPrefab = new AddRed100Pocket();
        RunManager.Instance.activeModifiers.Add(addRed100PocketPrefab);
    }
}
