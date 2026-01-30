using System.Collections.Generic;
using UnityEngine;

public class SpinContext
{
    // Variables
    #region Variables

    public List<RoulettePocket> pockets { get; private set; }
    public int ballCount { get; private set; }
    public List<ISpinModifier> modifiers { get; private set; }

    #endregion



    // Constructor
    #region Constructor

    public SpinContext(List<RoulettePocket> pockets, int ballCount = 1)
    {
        this.pockets = new List<RoulettePocket>(pockets);
        this.ballCount = ballCount;
        this.modifiers = new List<ISpinModifier>();
    }

    #endregion



    // Functions

}
