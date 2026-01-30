using UnityEngine;
using System;
using System.Collections.Generic;

public class RouletteWheel : MonoBehaviour
{
    // Variables
    #region Variables

    [Header("Wheel Info")]
    [SerializeField] private Wheel wheelDefinition;
    private List<RoulettePocket> pockets;

    #endregion


    // Events
    #region Events

    public event Action<RoulettePocket> OnSpinResolved;

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
        SpinContext context = new SpinContext(pockets);

        foreach (var modifier in context.modifiers)
        {
            modifier.ApplyModifier(context);
        }

        RoulettePocket result = GetRandomPocketFromContext(context);
        ResolveSpin(result);
    }

    // test function
    private RoulettePocket GetRandomPocketFromContext(SpinContext context)
    {
        int index = UnityEngine.Random.Range(0, context.pockets.Count);
        return context.pockets[index];
    }

    private void ResolveSpin(RoulettePocket pocket)
    {
        OnSpinResolved?.Invoke(pocket);
    }

    #endregion
}
