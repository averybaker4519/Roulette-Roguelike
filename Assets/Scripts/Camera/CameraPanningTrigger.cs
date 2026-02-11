using System.Collections;
using UnityEngine;

public class CameraPanningTrigger : MonoBehaviour
{
    // Variables

    #region Variables

    [Header("Camera Panning Settings")]
    public Transform targetPosition;
    public float panSpeed = 5f;
    public Camera mainCamera;

    private float initialZPosition;
    private float distanceThreshold = .01f;


    #endregion


    public void BeginPan()
    {
        StartCoroutine(Pan());
    }


    // Functions

    #region Functions

    public IEnumerator Pan()
    {
        Vector3 target = new Vector3(targetPosition.position.x, targetPosition.position.y, initialZPosition);

        while (Vector3.Distance(mainCamera.transform.position, target) >= distanceThreshold)
        {
            Vector3 newPosition = Vector3.Lerp(mainCamera.transform.position, target, panSpeed * Time.deltaTime);
            mainCamera.transform.position = newPosition;
            yield return null;
        }
        print("Camera has reached the target position.");
        StopCoroutine(Pan());
    }

    private void Start()
    {
        initialZPosition = mainCamera.transform.position.z;
    }

    #endregion
}
