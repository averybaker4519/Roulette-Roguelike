using UnityEngine;
using TMPro;

public class PocketObject : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    [SerializeField] Transform textRotate;
    [SerializeField] MeshRenderer quad;
    
    RoulettePocket pocket;

    public void SetPocket(RoulettePocket p)
    {
        pocket = p;

        text.text = p.baseNumber.ToString();

        Color c = p.baseColor switch
        {
            RoulettePocket.PocketColor.RED => Color.red,
            RoulettePocket.PocketColor.BLACK => Color.black,
            RoulettePocket.PocketColor.GREEN => Color.green,
            _ => Color.magenta
        };

        quad.material.SetColor("_Color", c);
    }

    public void SetPosition(int index, float offset)
    {
        transform.localRotation = Quaternion.Euler(0, index * offset, 0);

        textRotate.localRotation = Quaternion.Euler(0, offset / 2f, 0);

        quad.material.SetFloat("_Rotation", offset);
    }
}
