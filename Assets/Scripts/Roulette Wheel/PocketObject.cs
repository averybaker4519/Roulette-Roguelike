using UnityEngine;
using TMPro;

public class PocketObject : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    [SerializeField] Transform textRotate;
    
    RoulettePocket pocket;

    public void SetPocket(RoulettePocket p)
    {
        pocket = p;

        text.text = p.baseNumber.ToString();
    }

    public void SetPosition(int index, float offset)
    {
        transform.localRotation = Quaternion.Euler(0, index * offset, 0);

        textRotate.localRotation = Quaternion.Euler(0, offset / 2f, 0);
    }
}
