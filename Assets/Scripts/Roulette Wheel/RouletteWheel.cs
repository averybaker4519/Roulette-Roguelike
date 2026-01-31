using UnityEngine;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;

public class RouletteWheel : MonoBehaviour
{
    // Variables
    #region Variables

    [Header("Wheel Info")]
    [SerializeField] public Wheel wheelDefinition;
    public List<RoulettePocket> pockets;

    [Header("Prefabs")]
    [SerializeField] private PocketObject pocketObject;

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
        GenerateWheel();
        RunManager.Instance.currentWheel = this;
    }

    #region Generation

    public void GenerateWheel()
    {
        PocketObject[] objects = FindObjectsByType<PocketObject>(FindObjectsSortMode.None);

        for (int i = 0; i < objects.Length; i++)
        {
            Destroy(objects[i].gameObject);
        }
        
        float offset = 360f / pockets.Count;
        
        for (int i = 0; i < pockets.Count; i++)
        {
            PocketObject o = Instantiate(pocketObject, transform);

            o.SetPocket(pockets[i]);

            o.SetPosition(i, offset);
        }
    }

    public void AddNewPocket(RoulettePocket pocket)
    {
        pockets.Add(pocket);

        GenerateWheel();
    }

    #endregion



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
            modifier.ApplyModifier(context, this);
        }
    }



    #endregion



    #endregion
}
