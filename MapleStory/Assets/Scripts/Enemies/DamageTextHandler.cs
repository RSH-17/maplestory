using NUnit.Framework;
using Unity.Mathematics;
using UnityEngine;

public class DamageTextHandler : MonoBehaviour
{
    [SerializeField] private GameObject damageTextPrefab;
    [SerializeField] private float verticalOffset = 1f;
    private HealthHandler health;

    void OnEnable()
    {
        health = GetComponent<HealthHandler>();
        if (health != null)
        {
            health.OnDamaged += Show;
        }
    }

    void OnDisable()
    {
        if (health != null)
        {
            health.OnDamaged -= Show;
        }
    }

    public void Show(int damage)
    {
        if (damageTextPrefab == null)
        {
            return;
        }

        Canvas worldCanvas = CanvasManager.Instance?.worldCanvas;
        if (worldCanvas == null)
        {
            return;
        }

        GameObject dt = Instantiate(damageTextPrefab, Vector3.zero, Quaternion.identity);
        dt.transform.SetParent(worldCanvas.transform, false);
        dt.transform.position = transform.position + Vector3.up * verticalOffset;

        var dmgtxt = dt.GetComponent<DamageText>();
        if (dmgtxt != null)
            dmgtxt.setDamageText(damage);
    }

}