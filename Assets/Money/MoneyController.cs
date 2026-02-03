using UnityEngine;
using UnityEngine.UIElements;
using System;
public class MoneyController : MonoBehaviour
{
    public static MoneyController Instance { get; private set; }

    private void Awake()
    {
        // If an instance already exists and it's not this one, destroy this
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // Set the instance
        Instance = this;
    }
    public static event Action<int> OnMoneyUpdated;
    private int money = 500;

    void Start()
    {
        OnMoneyUpdated?.Invoke(money);
    }

    public bool TryDeduct(int amount)
    {
        if (money < amount)
            return false;

        money -= amount;
        OnMoneyUpdated?.Invoke(money);
        return true;
    }

    public bool TryAdd(int amount)
    {
        money += amount;
        OnMoneyUpdated?.Invoke(money);
        return true;
    }

    // private MoneyView moneyUI;
    
    private void AddMoney(int amount){
        money += amount;
    }

    public int GetMoney(){
        return money;
    }

}
