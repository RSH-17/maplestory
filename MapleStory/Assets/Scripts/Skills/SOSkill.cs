using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "SOSkill", menuName = "Scriptable Objects/SOSkill")]
public class SOSkill : ScriptableObject
{
    public string sName;
    public string description;

    public Key key;

    public float baseDamage;
    public float coefficient;

    public int useResourse;
    public int colldown;

    public string animName;
    public GameObject BeamPrefab;
    public Sprite icon;
}
