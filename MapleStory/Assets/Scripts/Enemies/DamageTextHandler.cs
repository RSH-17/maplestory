using NUnit.Framework;
using UnityEngine;

public class DamageTextHandler : MonoBehaviour
{
    [SerializeField] private GameObject damageTextPrefab;
    [SerializeField] private float verticalOffset = 1f;

    public void Show(int damage)
    {
        if (damageTextPrefab == null) return;

        Canvas worldCanvas = CanvasManager.Instance?.worldCanvas;
        if (worldCanvas == null) return;

        GameObject dt = Instantiate(damageTextPrefab, Vector3.zero, Quaternion.identity);
        dt.transform.SetParent(worldCanvas.transform, false);
        dt.transform.position = transform.position + Vector3.up * verticalOffset;

        var dmgtxt = dt.GetComponent<DamageText>();
        if (dmgtxt != null)
            dmgtxt.setDamageText(damage);
    }

}