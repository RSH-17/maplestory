using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

public class MonsterPatrol : MonoBehaviour
{
    public MonsterData data;
    public testmob testmob;

    private float speed;
    private float patrolDistance;
    private Vector2 startPos;
    private int direction = 1;


    void Start()
    {
        speed = data.moveSpeed;
        patrolDistance = data.patrolDistance;

        startPos = transform.position;
        if(testmob == null) testmob = GetComponent<testmob>();
    }


    void Update()
    {
        if (testmob != null && testmob.getIsDead())
        {
            Debug.Log("dead");
            return;
        }
        transform.Translate(Vector2.left * speed * direction * Time.deltaTime);

        float moved = transform.position.x - startPos.x;

        if (Mathf.Abs(moved) >= patrolDistance)
        {
            direction *= -1;
            filp();
        }
    }

    void filp()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
