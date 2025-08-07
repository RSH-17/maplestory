using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "SOSkill", menuName = "Scriptable Objects/SOSkill")]
public abstract class SOSkill : ScriptableObject
{
    public string skillName;
    public string description;

    public Key key;

    public int useResourse;
    public int cooldown;

    public GameObject prefab;
    public Sprite icon;

    public abstract void Activate(GameObject user);
}