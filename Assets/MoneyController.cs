using UnityEngine;
using UnityEngine.UIElements;
public class MoneyController : MonoBehaviour
{
    private int money;

    // private MoneyView moneyUI;
    
    private void AddMoney(int amount){
        money += amount;
    }

    public int GetMoney(){
        return money;
    }

}
