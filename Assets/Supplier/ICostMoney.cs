using UnityEngine;
using System;
public interface ICostMoney{
    public static event Action<int> OnDeductMoney;

    void DeductMoney(int amount){
        OnDeductMoney?.Invoke(amount);
    }
}