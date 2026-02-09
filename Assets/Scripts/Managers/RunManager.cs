using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class RunManager : MonoBehaviour
{
    // Variables
    #region Variables

    public static RunManager Instance;

    [Header("Run Info")]
    public RouletteWheel currentWheel;
    public int chips;
    public List<IGameModifiers> activeModifiers;

    #endregion




    // Functions
    #region RunManager Instance

    // makes script into singleton, called in Awake()
    public void HandleGameStateManagerInstance()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        else
        {
            Destroy(this);
        }
    }

    #endregion


    #region Modifiers Management

    public void AddModifier(IGameModifiers modifier)
    {
        if (modifier == null) return;

        if (activeModifiers == null)
        {
            activeModifiers = new List<IGameModifiers>();
        }

        activeModifiers.Add(modifier);
        print("Added Modifier: " + modifier.ToString());

    }

    public void RemoveModifier(IGameModifiers modifier)
    {
        if (activeModifiers == null || modifier == null) return;
        activeModifiers.Remove(modifier);
    }


    #region On Spin Modifiers
    public void HandleOnSpinModifiers()
    {
        // Pull any active spin modifiers from the RunManager into this spin's context
        if (Instance != null && Instance.activeModifiers != null)
        {
            foreach (var gameMod in RunManager.Instance.activeModifiers)
            {
                if (gameMod is ISpinModifier spinModifier)
                {
                    currentWheel.context.modifiers.Add(spinModifier);
                }
            }
        }

        foreach (var modifier in currentWheel.context.modifiers)
        {
            modifier.ApplyModifier(currentWheel.context, currentWheel);
        }
    }

    #endregion


    #endregion


    #region Money Management

    public void AddChips(int amount)
    {
        chips += amount;
        Debug.Log("Added " + amount + " chips. Total chips: " + chips);
    }

    public void RemoveChips(int amount)
    {
        if (HasEnoughChips(amount))
        {
            chips -= amount;
            Debug.Log("Removed " + amount + " chips. Total chips: " + chips);
        }
    }
    public bool HasEnoughChips(int amount)
    {
        return chips >= amount;
    }

    #endregion



    #region Built-in functions

    private void Awake()
    {
        HandleGameStateManagerInstance();

        if (activeModifiers  == null)
        {
            activeModifiers = new List<IGameModifiers>();
        }
    }

    private void OnEnable()
    {
        currentWheel.OnSpinStart += HandleOnSpinModifiers;
    }

    #endregion
}
