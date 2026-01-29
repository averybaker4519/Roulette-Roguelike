using NUnit.Framework;
using UnityEngine;
using System;
using System.Collections.Generic;

public class RouletteWheelManager : MonoBehaviour
{
    // Variables
    #region Variables

    [Header("Wheel Info")]
    [SerializeField] private Wheel wheelDefinition;
    private List<RoulettePocket> pockets;

    #endregion


    // Events
    #region Events

    public event Action<RoulettePocket> OnPocketLanded;

    #endregion



    // Functions
    #region Functions

    private void Awake()
    {
        pockets = new List<RoulettePocket>(wheelDefinition.pockets);
    }

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
