using UnityEngine;

[CreateAssetMenu(fileName = "MonsterData", menuName = "Scriptable Objects/Monster")]
public class MonsterData : ScriptableObject
{
    //이름
    public string monsterName;
    //체력
    public float maxHealth;
    //이동속도
    public float moveSpeed;
    //공격속도
    public float attackSpeed;
    //경험치
    public int expReward;
    //공격력
    public int attackForce;
    //방어력
    public int defenceForce;
    //레벨
    public int monsterLevel;
}
