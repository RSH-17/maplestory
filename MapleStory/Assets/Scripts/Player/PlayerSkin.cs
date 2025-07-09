using UnityEngine;

public class PlayerSkin : MonoBehaviour
{
    Color srColor;
    SpriteRenderer spriter;
    public Animator anim;
    public AnimatorOverrideController aoc;

    void Start()
    {
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        srColor = spriter.color;
        srColor.a = 0;
        spriter.color = srColor;

        if (aoc != null)
            anim.runtimeAnimatorController = aoc;
    }

    public void EquipItem(AnimationClip[] clips)
    {
        string common = "Player_Body_";

        if (clips != null && clips.Length >= 6)
        {
            spriter.color = Color.white;
            aoc[common + "attack"] = clips[0];
            aoc[common + "DMG"] = clips[1];
            aoc[common + "idle"] = clips[2];
            aoc[common + "idle_weapon"] = clips[3];
            aoc[common + "walk"] = clips[4];
            aoc[common + "walk_weapon"] = clips[5];

            anim.runtimeAnimatorController = aoc;
        }
        else
        {
            srColor.a = 0;
            spriter.color = srColor;
            aoc[common + "attack"] = null;
            aoc[common + "DMG"] = null;
            aoc[common + "idle"] = null;
            aoc[common + "idle_weapon"] = null;
            aoc[common + "walk"] = null;
            aoc[common + "walk_weapon"] = null;

            anim.runtimeAnimatorController = aoc;
        }
    }
}
