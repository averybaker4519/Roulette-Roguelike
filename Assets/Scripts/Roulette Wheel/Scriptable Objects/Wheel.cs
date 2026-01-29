using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Roulette/Wheel")]
public class Wheel : ScriptableObject
{
    // Variables
    #region Variables

    [Header("Wheel Info")]
    public int wheelID;
    public List<RoulettePocket> pockets;

    #endregion
}
