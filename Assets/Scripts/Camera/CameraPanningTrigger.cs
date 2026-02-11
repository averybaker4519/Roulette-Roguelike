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

    private static CameraPanningTrigger activePanner;
    private Coroutine panCoroutine;


    #endregion


    public void BeginPan()
    {
        // if another pan is already happenning, stop it before starting a new one
        if (activePanner != null && activePanner != this)
        {
            activePanner.StopCurrentPan();
        }

        // if this pan is already happenning, stop it before starting a new one
        if (panCoroutine != null)
        {
            StopCoroutine(panCoroutine);
            panCoroutine = null;
        }

        activePanner = this;
        panCoroutine = StartCoroutine(Pan());
    }


    // Functions

    #region Functions

    private void StopCurrentPan()
    {
        if (panCoroutine != null)
        {
            StopCoroutine(panCoroutine);
            panCoroutine = null;
        }

        if (activePanner == this)
        {
            activePanner = null;
        }
    }

    public IEnumerator Pan()
    {
        Vector3 target = new Vector3(targetPosition.position.x, targetPosition.position.y, initialZPosition);

        while (Vector3.Distance(mainCamera.transform.position, target) >= distanceThreshold)
        {
            Vector3 newPosition = Vector3.Lerp(mainCamera.transform.position, target, panSpeed * Time.deltaTime);
            mainCamera.transform.position = newPosition;
            yield return null;
        }

        StopCoroutine(Pan());
    }

    private void Start()
    {
        initialZPosition = mainCamera.transform.position.z;
    }

    #endregion
}
