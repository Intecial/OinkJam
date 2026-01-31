using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    

    public void OnShopButtonClick(InputAction.CallbackContext context){
        if(context.performed){
            Debug.Log("Shop Button Clicked");
        }
    }
}
