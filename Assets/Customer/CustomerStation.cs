using UnityEngine;

public class CustomerStation : MonoBehaviour, IStation
{
    [SerializeField]
    private ItemConfig bottleConfig;

    [SerializeField]
    private IngredientConfig ingredientConfig;

    private CustomerModel customerModel;

    private void Start() {
        InitializeCustomerStation();
    }

    // Will BE Controlled by something else later
    public void InitializeCustomerStation(){
        BottleModel bottleModel = new BottleModel(bottleConfig);
        bottleModel.AddIngredient(new IngredientModel(ingredientConfig));
        customerModel = new CustomerModel(bottleModel);
    }
    public void InteractStation(PlayerHandController playerHandController)
    {
        if(playerHandController.isHoldingItem()){
            GameObject heldItem = playerHandController.GetHeldItem();
            if(heldItem.TryGetComponent<Bottle>(out var bottle)){
                if(customerModel.GiveBottle(bottle.Model)){
                    playerHandController.ConsumeObject();
                    
                } else {
                    Debug.Log("Wrong Ingredient!");
                }
            }
        }
    }

}
