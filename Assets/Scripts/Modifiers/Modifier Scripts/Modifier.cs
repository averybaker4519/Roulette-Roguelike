using UnityEngine;

[System.Serializable]
public abstract class Modifier : ScriptableObject
{
    // Variables

    #region Variables

    [Header("Universal Upgrade Data")]
    public string modifierName;
    //[HideInInspector] public string modifierDescription;

    #endregion



    // Functions

    public abstract IGameModifiers CreateModifier();
}
