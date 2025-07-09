using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 3f;
    public float jumpPower = 10f;

    public bool isGrounded { get; private set; }
    public float inputValue { get; private set; }

    Rigidbody2D rigid;
    RaycastHit2D rayHit;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    public void handleMovement()
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

                if (rayHit.distance < 0.8f)
                    isGrounded = true;
            }
        }
    }

    // Character Move Direction Input : Key Arrow
    private void OnMove(InputValue value)
    {
        inputValue = value.Get<Vector2>().x;
    }

    // Character Jump : Key Alt
    private void OnJump()
    {
        if (isGrounded)
            rigid.AddForceY(jumpPower, ForceMode2D.Impulse);

        isGrounded = false;
    }
}
