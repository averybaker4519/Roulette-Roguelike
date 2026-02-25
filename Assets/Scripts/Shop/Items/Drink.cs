using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "Shop/Drink")]
public class Drink : ShopItem
{
    // Variables

    #region Variables

    [Header("Drink Specific Info")]
    public DrinkRarity rarity;

    #endregion
}
