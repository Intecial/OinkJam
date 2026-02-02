using UnityEngine;
using UnityEngine.UIElements;
using System;
public class MoneyController : MonoBehaviour
{
    public static event Action<int> OnDeductMoney;
    private static int money;

    public static bool TryDeduct(int amount)
    {
        if (money < amount)
            return false;

        money -= amount;
        OnDeductMoney?.Invoke(amount);
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
