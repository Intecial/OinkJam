using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementController : MonoBehaviour
{
    private Vector2 moveInput;
    [SerializeField]
    private Transform player;

    [SerializeField]
    private Transform raycast;

    [SerializeField]
    private float moveSpeed = 5f;
    public float rotateSpeed = 720f;

    [SerializeField] private Rigidbody2D rb;

    void Update()
    {
        if (moveInput.sqrMagnitude > 0.001f)
        {
            float angle = Mathf.Atan2(moveInput.y, moveInput.x) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(0f, 0f, angle - 90f);
            player.transform.rotation = Quaternion.RotateTowards(
                player.transform.rotation,
                targetRotation,
                rotateSpeed * Time.deltaTime
            );
        }
    }

    public void OnMove(InputAction.CallbackContext context){
        
        moveInput = context.ReadValue<Vector2>();
    }

    void FixedUpdate(){
        Vector2 movement = new Vector2(moveInput.x,  moveInput.y);
        rb.MovePosition(rb.position + moveSpeed * Time.fixedDeltaTime * movement);
    }

    public void StopMovement(){
        PlayerInput playerInput = GetComponent<PlayerInput>();
        playerInput.SwitchCurrentActionMap("UIInput");
    }

    public void ResumeMovement()
    {
        PlayerInput playerInput = GetComponent<PlayerInput>();
        playerInput.SwitchCurrentActionMap("PlayerMovement");
    }
}
