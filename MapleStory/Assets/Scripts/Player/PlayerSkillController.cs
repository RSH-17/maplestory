using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using Unity.VisualScripting;

public class PlayerSkillController : MonoBehaviour
{
    private PlayerAnimation playerAnimation;
    private PlayerStats playerStats;

    public List<SOSkill> skillList;
    private Dictionary<Key, int> skillBindings = new Dictionary<Key, int>();
    private bool[] isOnCooldown;

    void Awake()
    {
        playerAnimation = GetComponent<PlayerAnimation>();
        playerStats = GetComponent<PlayerStats>();
        
        // ��ų�� ��ϵ� Ű ���� skillBindings�� �Ҵ������.
         for (int i = 0;  i < skillList.Count; i++)
        {
            skillBindings[skillList[i].key] = i;
        }
            

        isOnCooldown = new bool[skillList.Count];
    }

    public void KeyDownCheck(Key key)
    {
        foreach (var kv in skillBindings)
        {
            if (kv.Key == key)
            {
                int index = kv.Value;
                if (!isOnCooldown[index])
                    StartCoroutine (UseSkill(index));
            }
        }
    }

    IEnumerator UseSkill(int index)
    {
        SOSkill skill = skillList[index];
        isOnCooldown[index] = true;
        
        // playerAnimation.SpriteFlipX

        // ����Ʈ ����
        if (skill.prefab != null)
            Instantiate(skill.prefab, transform.position, Quaternion.identity);

            
        yield return new WaitForSeconds(skill.cooldown);
        isOnCooldown[index] = false;
    }
}