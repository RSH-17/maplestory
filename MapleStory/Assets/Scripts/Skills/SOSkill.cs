using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "SOSkill", menuName = "Scriptable Objects/SOSkill")]
public class SOSkill : ScriptableObject
{
    public string sName;
    public string description;

    public Key key;
    
    public float baseDamage; // �⺻ ������ (����)
    public float coefficient; // ��ų ���

    public int useResourse;
    public int cooldown;

    public GameObject prefab;
    public Sprite icon;
}
