using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    
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
            if (playerHandController.isHoldingItem())
            {
                if(raycastHandler.GetCollider() != null)
                {
                    
                }

                playerHandController.DropItem();
            } 
            else{
                if(raycastHandler.GetCollider() != null)
                {
                    raycastHandler.GetCollidedGameObject().GetComponent<Interactable>().Interact();
                }
            }
        }
    }

    public void OnShopButtonClick(InputAction.CallbackContext context){
        if(context.performed){
            Debug.Log("Shop Button Clicked");
        }
    }
}
