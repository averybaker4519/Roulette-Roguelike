using UnityEngine;

public class TestSpin : MonoBehaviour
{
    // #########################################################################################
    // TEST SCRIPT
    // #########################################################################################

    // Variables
    [SerializeField] RouletteWheelManager wheel;



    // Functions
    private void OnEnable()
    {
        wheel.OnPocketLanded += HandlePocketLanded;
    }

    private void OnDisable()
    {
        wheel.OnPocketLanded -= HandlePocketLanded;
    }

    public void SpinWheel()
    {
        wheel.Spin();
    }

    public void HandlePocketLanded(RoulettePocket pocket)
    {
        print(pocket.number + " " + pocket.color);
    }
}
