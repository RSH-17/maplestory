using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    public float jumpPower;

    float inputValue;

    Rigidbody2D rigid;
    Animator anim;
    SpriteRenderer spriter;
    RaycastHit2D rayHit;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriter = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        // Character Move
        rigid.linearVelocityX = inputValue * speed;

        // Landing Platform
        if (rigid.linearVelocityY < 0)
        {
            Debug.DrawRay(rigid.position, Vector3.down, new Color(0, 1, 0));
            rayHit = Physics2D.Raycast(rigid.position, Vector2.down, 1, LayerMask.GetMask("Platform"));

            if (rayHit.collider != null)
            {
                // Jump Animation false
                if (rayHit.distance < 0.8f)
                    anim.SetBool("isJump", false);   
            }
        }
    }

    private void LateUpdate()
    {
        // Walk Animation
        anim.SetBool("isWalk", inputValue != 0);

        // Character Direction Sprite Flip
        if (inputValue != 0)
            spriter.flipX = inputValue > 0;
    }

    // Character Move Direction Input : Key Arrow
    private void OnMove(InputValue value)
    {
        inputValue = value.Get<Vector2>().x;
    }

    // Character Jump : Key Alt
    private void OnJump()
    {
        if (!anim.GetBool("isJump"))
            rigid.AddForceY(jumpPower, ForceMode2D.Impulse);

        // Jump Animation
        anim.SetBool("isJump", true);
    }
}
