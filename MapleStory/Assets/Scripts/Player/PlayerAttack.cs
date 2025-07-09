using UnityEditor.Rendering;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // public StatData statData;

    public bool isAttack { get; private set; }

    void Awake()
    {
    }

    public void TakeDamage(int damage)
    {

    }

    private void OnAttack()
    {
        isAttack = true;
    }
}
