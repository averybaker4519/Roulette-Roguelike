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
    //public int money;
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

    #endregion


    #region Money Management

    public void AddChips(int amount)
    {
        chips += amount;
    }

    public void RemoveChips(int amount)
    {
        if (HasEnoughChips(amount))
        {
            chips -= amount;
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
        if (activeModifiers  == null)
        {
            activeModifiers = new List<IGameModifiers>();
        }

        HandleGameStateManagerInstance();
    }

    #endregion
}
