using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    public static event Action OnInteractClicked;
    
    [SerializeField]
    private RaycastHandler raycastHandler;

    [SerializeField]
    private PlayerHandController playerHandController;

    [SerializeField]
    private PlayerMovementController playerMovementController;

    public void OnInteractClick(InputAction.CallbackContext context)
    {
        
        if (context.performed)
        {
            OnInteractClicked?.Invoke();
        }
    }

    public void OnShopButtonClick(InputAction.CallbackContext context){
        if(context.performed){
            Debug.Log("Shop Button Clicked");
        }
    }
}
