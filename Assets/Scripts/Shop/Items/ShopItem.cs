using UnityEngine;
using UnityEngine.UI;

public class ShopItem : ScriptableObject
{
    // Variables

    #region Variables

    [Header("Universal Item Info")]

    public string itemName;
    public int price;
    public Image itemImage;
    public string description;
    public IGameModifiers modifier;

    #endregion
}
