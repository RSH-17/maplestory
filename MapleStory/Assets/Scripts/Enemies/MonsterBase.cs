using Unity.VisualScripting;
using UnityEngine;
using System.Collections;

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

        //임시 데미지 코드
        StartCoroutine(Test_Damage(1000));
    }

    IEnumerator Test_Damage(int dmg)
    {
        yield return new WaitForSeconds(3f);
        healthHandler.TakeDamage(dmg);
    }


    void Update()
    {
        if (!healthHandler.IsDead()) patrolHandler.Move();
    }
}
