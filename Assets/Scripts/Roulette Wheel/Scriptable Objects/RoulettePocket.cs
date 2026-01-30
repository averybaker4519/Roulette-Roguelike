using UnityEngine;
using System;
using System.Collections.Generic;

[System.Serializable]
public struct RoulettePocket
{
    public enum PocketColor
    {
        RED,
        BLACK,
        GREEN
    }

    // Variables
    #region Variables

    [Header("Info")]
    public int baseNumber;
    public PocketColor baseColor;
    public float basePayout;

    public RoulettePocket(int number, PocketColor color, float payout = 35f)
    {
        this.baseNumber = number;
        this.baseColor = color;
        this.basePayout = payout;
    }

    #endregion

}
