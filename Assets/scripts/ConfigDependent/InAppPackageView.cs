using TMPro;
using UnityEngine;

public class InAppPackageView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMesh;

    public void ShowPrice(float price)
    {
        textMesh.text = string.Format(textMesh.text, price.ToString());
    }
}
