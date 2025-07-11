using Unity.VisualScripting;
using UnityEngine;

public class MonsterBase : MonoBehaviour
{
    private IDamageable damageable;
    private Animator animator;
    private PatrolHandler patrolHandler;
    private HealthHandler healthHandler;
    

    public MonsterData monsterData;

    void Awake()
    {
        animator = GetComponent<Animator>();
        damageable = GetComponent<IDamageable>();
        patrolHandler = GetComponent<PatrolHandler>();
        healthHandler = GetComponent<HealthHandler>();
    }


    void Update()
    {
        if (!healthHandler.IsDead()) patrolHandler.Move();
    }
}
