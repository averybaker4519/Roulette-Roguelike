using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ShopItem : ScriptableObject
{
    // Variables

    #region Variables

    [Header("Universal Item Info")]

    public string itemName;
    public int price;
    public Image itemImage;
    //public string description;
    public Modifier modifier;

    #endregion
}
