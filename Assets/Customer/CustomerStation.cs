using System;
using UnityEngine;

public class CustomerStation : MonoBehaviour, IStation
{
    public static event Action<CustomerModel> OnCustomerInteracted;

    private CustomerView customerView;
    [SerializeField]
    private SpriteRenderer CustomerSprite;
    private CustomerModel customerModel;

    public bool IsEmpty(){
        return customerModel == null;
    }
    void Awake()
    {
        Registry<CustomerStation>.TryAdd(this);
        customerModel = null;
        customerView = GetComponent<CustomerView>();
    }

    void OnDestroy()
    {
        Registry<CustomerStation>.Remove(this);
    }

    // Will BE Controlled by something else later
    public void InitializeCustomerStation(CustomerModel customerModel){
        AddCustomer(customerModel);
    }
    public void InteractStation(PlayerHandController playerHandController)
    {
        if(playerHandController.isHoldingItem()){
            GameObject heldItem = playerHandController.GetHeldItem();
            if(heldItem.TryGetComponent<Bottle>(out var bottle)){
                if(customerModel.GiveBottle(bottle.Model)){

                    // Add Money
                    MoneyController.Instance.TryAdd(customerModel.totalPay);
                    playerHandController.ConsumeObject();
                    ClearCustomer();
                } else {
                    Debug.Log("Wrong Ingredient!");
                }
            }
        }
        else
        {
            if(customerModel != null)
            {
                OnCustomerInteracted?.Invoke(customerModel);  
            }
        }
    }

    private void AddCustomer(CustomerModel customerModel){
        this.customerModel = customerModel;
        CustomerSprite.enabled = true;
    }

    private void ClearCustomer()
    {
        customerModel = null;
        CustomerSprite.enabled = false;
    }

}
