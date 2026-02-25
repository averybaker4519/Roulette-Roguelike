using UnityEngine;

[System.Serializable]
public abstract class Modifier : MonoBehaviour
{
    // Variables

    #region Variables

    [Header("Universal Upgrade Data")]
    //[HideInInspector] 
    public int amount = 1;
    //[HideInInspector] public string description = "Description of the modifier's effect.";

    #endregion



    // Functions

    public abstract IGameModifiers CreateModifier();
}
