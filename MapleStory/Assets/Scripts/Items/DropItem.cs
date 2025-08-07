using UnityEngine;

public class DropItem : MonoBehaviour, ICollectable
{
    public void OnCatch(GameObject collector)
    {
        collector.GetComponent<ICollector>()?.Apply(this);
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