using System;
using UnityEngine;

public class DropItem : MonoBehaviour, ICollectable
{
    [SerializeField] private ScriptableObject effectSO;
    ICollectEffect effect;

    void Awake()
    {
        effect = effectSO as ICollectEffect;
    }

    public void OnCatch(GameObject collector)
    {
        effect?.Apply(collector, this);
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            OnCatch(other.gameObject);
        }
    }
}