using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class ShopItem : ScriptableObject
{
    // Variables

    #region Variables

    [Header("Universal Item Info")]

    public string itemName;
    public int price;
    public Sprite itemImage;
    public string description;
    public Modifier modifier;

    #endregion
}
