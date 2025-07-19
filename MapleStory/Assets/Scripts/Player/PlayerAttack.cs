using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using System.Threading.Tasks;

public class PlayerAttack : MonoBehaviour
{
    public bool isAttack { get; private set; }

    public SOSkill[] skills;

    private PlayerStats playerStats;
    private PlayerSkillController playerSkillController;

    void Awake()
    {
        playerStats = GetComponent<PlayerStats>();
        playerSkillController = GetComponent<PlayerSkillController>();

    }

    private async Task OnAttack()
    {
        isAttack = true;

        foreach(KeyControl key in Keyboard.current.allKeys)
        {
            if (key == null) continue;

            if (key.wasPressedThisFrame)
            {
                Debug.Log("Key Pressed : " + key.displayName);
                playerSkillController.keyDownCheck(key.keyCode);
            }
        } 

        await Task.Delay(500);
        isAttack = false;
    }
}
