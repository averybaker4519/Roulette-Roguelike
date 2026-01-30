using UnityEngine;
using System;
using System.Collections.Generic;

public class RouletteWheel : MonoBehaviour
{
    // Variables
    #region Variables

    [Header("Wheel Info")]
    [SerializeField] public Wheel wheelDefinition;
    public List<RoulettePocket> pockets;

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



    #region Spinning logic

    public void Spin()
    {
        SpinContext context = new SpinContext(pockets);

        HandleOnSpinModifiers(context);

        RoulettePocket result = GetRandomPocketFromContext(context);
        ResolveSpin(result);
        print(context.pockets.Count);
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



    #region On Spin Modifiers
    private void HandleOnSpinModifiers(SpinContext context)
    {
        // Pull any active spin modifiers from the RunManager into this spin's context
        if (RunManager.Instance != null && RunManager.Instance.activeModifiers != null)
        {
            foreach (var gameMod in RunManager.Instance.activeModifiers)
            {
                if (gameMod is ISpinModifier spinModifier)
                {
                    context.modifiers.Add(spinModifier);
                }
            }
        }

        foreach (var modifier in context.modifiers)
        {
            print("Applying modifier: " + modifier.GetType().Name);
            modifier.ApplyModifier(context, this);
        }
    }

    #endregion

    #endregion
}
