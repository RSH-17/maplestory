using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/GenericSkill")]
public class GenericSkill : SOSkill
{
    public List<SkillEffect> effects;

    public override void Activate(GameObject user)
    {
        foreach (var effect in effects)
        {
            effect.Apply(user);
        }
    }
}
