using UnityEngine;

public class TestSpin : MonoBehaviour
{
    // Variables
    [SerializeField] RouletteWheel wheel;



    // Functions
    public void SpinWheel()
    {
        wheel.Spin();
    }
}
