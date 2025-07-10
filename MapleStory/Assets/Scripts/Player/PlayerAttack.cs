using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    public bool isAttack { get; private set; }
    // public string motionName { get; private set; }

    public SOSkill[] skills;

    private PlayerData playerData;

    void Awake()
    {
        playerData = GetComponent<PlayerData>();
    }

    public void ActiveSkill()
    {
    }

    private void OnAttack()
    {
        isAttack = true;
    }
}
