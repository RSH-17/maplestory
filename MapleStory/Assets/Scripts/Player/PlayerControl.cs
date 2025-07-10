using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private PlayerMovement movementModule;
    private PlayerAnimation animModule;

    void Awake()
    {
        movementModule = GetComponent<PlayerMovement>();
        animModule = GetComponent<PlayerAnimation>();
    }

    void FixedUpdate()
    {
        movementModule.handleMovement();
    }

    void LateUpdate()
    {
        animModule.handleAnimation();
    }
}
