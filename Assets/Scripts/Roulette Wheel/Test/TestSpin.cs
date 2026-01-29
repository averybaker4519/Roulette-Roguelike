using UnityEngine;

public class TestSpin : MonoBehaviour
{
    // #########################################################################################
    // TEST SCRIPT
    // #########################################################################################

    // Variables
    [SerializeField] RouletteWheel wheel;



    // Functions
    private void OnEnable()
    {
        wheel.OnSpinResolved += HandleSpinResolved;
    }

    private void OnDisable()
    {
        wheel.OnSpinResolved -= HandleSpinResolved;
    }

    public void SpinWheel()
    {
        wheel.Spin();
    }

    public void HandleSpinResolved(RoulettePocket pocket)
    {
        print(pocket.number + " " + pocket.color);
    }
}
