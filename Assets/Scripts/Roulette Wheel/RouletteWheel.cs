using NUnit.Framework;
using UnityEngine;
using System;
using System.Collections.Generic;

public class RouletteWheel : MonoBehaviour
{
    // Variables
    #region Variables

    [Header("Wheel Info")]
    public List<RoulettePocket> pockets;

    #endregion


    // Events
    #region Events

    public event Action<RoulettePocket> OnSpinCompleted;

    #endregion



    // Functions
    #region Functions

    public void Spin()
    {
        RoulettePocket result = GetRandomPocket();
        GetResult(result);
    }

    private RoulettePocket GetRandomPocket()
    {
        int index = UnityEngine.Random.Range(0, pockets.Count);
        return pockets[index];
    }

    private void GetResult(RoulettePocket pocket)
    {
        OnSpinCompleted?.Invoke(pocket);
    }

    #endregion
}
