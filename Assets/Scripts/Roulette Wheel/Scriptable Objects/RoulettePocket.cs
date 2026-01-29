using UnityEngine;
using System;
using System.Collections.Generic;


public enum PocketColor
{
    RED,
    BLACK,
    GREEN
}


[CreateAssetMenu(menuName = "Roulette/Pocket")]
public class RoulettePocket : ScriptableObject
{
    // Variables
    #region Variables

    [Header("Info")]
    public int pocketID;
    public int number;
    public PocketColor color;

    #endregion

}
