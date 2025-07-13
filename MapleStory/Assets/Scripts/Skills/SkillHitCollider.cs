using UnityEngine;

public class SkillHitCollider : MonoBehaviour
{
    public float damage;
    public float lifetime = 0.5f;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Monster"))
        {
            Debug.Log("Monster Attack");
        }
    }
}
