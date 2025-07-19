using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "SOSkill", menuName = "Scriptable Objects/SOSkill")]
public class SOSkill : ScriptableObject
{
    public string sName;
    public string description;

    public Key key;
    
    public float baseDamage; // 기본 데미지 (깡딜)
    public float coefficient; // 스킬 계수

    public int useResourse;
    public int cooldown;

    public GameObject prefab;
    public Sprite icon;
}
