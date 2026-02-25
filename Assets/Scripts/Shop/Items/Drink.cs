using UnityEngine;

[CreateAssetMenu(menuName = "Shop/Drinks")]
public class Drink : ShopItem
{
    // Variables

    #region Variables

    [Header("Drink Specific Info")]
    public DrinkRarity rarity;

    #endregion
}
