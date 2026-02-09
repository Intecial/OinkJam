using System;
using UnityEngine;

public class CustomerStation : MonoBehaviour, IStation
{
    public static event Action<CustomerModel> OnCustomerInteracted;

    private CustomerView customerView;
    [SerializeField]
    private SpriteRenderer CustomerSprite;

    [SerializeField]
    private GameObject highlight;

    private AudioSource source;

    [SerializeField]
    private AudioClip customerServed;

    [SerializeField]
    private AudioClip customerDenied;
    private CustomerModel customerModel;

    public bool IsEmpty(){
        return customerModel == null;
    }
    void Awake()
    {
        source = GetComponent<AudioSource>();
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
                    source.PlayOneShot(customerServed);
                    playerHandController.ConsumeObject();
                    ClearCustomer();
                } else {
                    source.PlayOneShot(customerDenied);
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

    public void Highlight()
    {
        highlight.SetActive(true);
    }

    public void RemoveHighlight()
    {
        highlight.SetActive(false);
    }
}
