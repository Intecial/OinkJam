using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementController : MonoBehaviour
{
    
    
    private Vector2 moveInput;

    [SerializeField]
    private float moveSpeed = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMove(InputAction.CallbackContext context){
        
        moveInput = context.ReadValue<Vector2>();

    }

    void FixedUpdate(){
        Vector3 movement = new Vector3(moveInput.x, 0, moveInput.y);
        transform.position += movement * moveSpeed * Time.deltaTime;
    }
}
