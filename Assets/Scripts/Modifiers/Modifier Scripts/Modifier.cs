using UnityEngine;

public abstract class Modifier : MonoBehaviour
{
    // Variables

    #region Variables

    [Header("Universal Upgrade Data")]
    public int amount = 1;

    #endregion



    // Functions

    public abstract IGameModifiers CreateModifier(RoulettePocket redPocket);
}
