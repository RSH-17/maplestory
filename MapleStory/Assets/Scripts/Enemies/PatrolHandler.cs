using UnityEditor.Tilemaps;
using UnityEngine;

public class PatrolHandler : MonoBehaviour
{
    [SerializeField] private MonsterData data;

    private Vector2 startPos;
    private int direction = 1;

    void Start()
    {
        startPos = transform.position;
    }

    public void Move()
    {
        float speed = data.moveSpeed;
        float patrolDistance = data.patrolDistance;

        transform.Translate(Vector2.left * speed * direction * Time.deltaTime);

        float movedDistance = transform.position.x - startPos.x;
        if (Mathf.Abs(movedDistance) >= patrolDistance)
        {
            direction *= -1;
            Flip();
        }
    }

    private void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}