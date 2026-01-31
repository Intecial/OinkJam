using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementController : MonoBehaviour
{
    
    
    private Vector2 moveInput;
    [SerializeField]
    private Transform player;

    [SerializeField]
    private float moveSpeed = 5f;
    public float rotateSpeed = 720f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        
    }


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
        Debug.Log(moveInput);
    }

    void FixedUpdate(){
        Vector3 movement = new Vector3(moveInput.x,  moveInput.y, 0);
        player.transform.position += movement * moveSpeed * Time.deltaTime;
    }
}
