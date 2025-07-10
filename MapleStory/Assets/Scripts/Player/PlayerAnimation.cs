using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private PlayerMovement movementModule;
    private PlayerAttack attackModule;

    Animator anim;
    SpriteRenderer spriter;

    bool SpriteFlipX;

    void Awake()
    {
        movementModule = GetComponent<PlayerMovement>();
        attackModule = GetComponent<PlayerAttack>();

        anim = GetComponent<Animator>();
        spriter = GetComponent<SpriteRenderer>();
    }

    public void handleAnimation()
    {
        // Jump Animation
        anim.SetBool("isJump", !movementModule.isGrounded);

        // Walk Animation
        anim.SetBool("isWalk", movementModule.inputValue != 0);

        // Direction Flip Sprite
        if (movementModule.inputValue != 0)
            SpriteFlipX = movementModule.inputValue > 0;
        PlayerFlip();

        // Attack Animation
        anim.SetBool("isAttack", attackModule.isAttack);
    }

    // Player Flip
    void PlayerFlip()
    {
        Vector3 thisScale = transform.localScale;
        if (SpriteFlipX)
        {
            thisScale.x = -Mathf.Abs(thisScale.x);
        }
        else
        {
            thisScale.x = Mathf.Abs(thisScale.x);
        }
        transform.localScale = thisScale;
    }
}
