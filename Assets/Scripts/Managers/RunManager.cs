using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class RunManager : MonoBehaviour
{
    // Variables
    #region Variables

    public static RunManager Instance;

    [Header("Run Info")]
    public int money;
    public int chips;
    public List<IGameModifiers> activeModifiers;// = new List<GameModifiers>();

    #endregion




    // Functions
    #region RunManager

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

    public void AddModifier(IGameModifiers modifier)
    {
        activeModifiers.Add(modifier);
    }

    #endregion



    #region Built-in functions

    private void Awake()
    {
        HandleGameStateManagerInstance();
    }

    #endregion
}
