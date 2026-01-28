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

    public event Action<RoulettePocket> OnPocketLanded;

    #endregion



    // Functions
    #region Functions

    // test logic
    public void Spin()
    {
        RoulettePocket result = GetRandomPocket();
        GetResult(result);
    }

    // test function
    private RoulettePocket GetRandomPocket()
    {
        int index = UnityEngine.Random.Range(0, pockets.Count);
        return pockets[index];
    }

    private void GetResult(RoulettePocket pocket)
    {
        OnPocketLanded?.Invoke(pocket);
    }

    #endregion
}
