using UnityEngine;
using System;
using System.Collections.Generic;


public enum PocketColor
{
    RED,
    BLACK
}


[CreateAssetMenu(menuName = "Roulette/Pocket")]
public class RoulettePocket : ScriptableObject
{

    #region Variables

    [Header("Info")]
    public int number;
    public PocketColor color;
    public int pocketID;

    [Header("Payout")]
    public float basePayout;

    #endregion

}
