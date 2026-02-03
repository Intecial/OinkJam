using System;
using System.Collections;
using UnityEngine;

public class CauldronModel
{
    public event Action<int> OnTimerTick;
    public  event Action OnBottleChange;

    public event Action OnBrewing;

    public event Action OnBrewingComplete;

    public  event Action OnIngredientChange;

    public event Action OnBottlePickUp;

    public BottleModel bottle { get; private set; }
    public IngredientModel ingredient { get; private set; }

    public bool isOccupied = false;
    private int timeTaken = 10;

    public int time;

    public BottleModel TakeBottle()
    {
        OnBottlePickUp.Invoke();
        BottleModel bottleModelCopy = new BottleModel(bottle);
        ClearBottle();
        return bottleModelCopy;
    }

    private void ClearBottle(){
        this.bottle = null;
        OnBottleChange.Invoke();
    }

    private void ClearIngredient(){
        this.ingredient = null;
        OnIngredientChange.Invoke();
    }

    public IEnumerator MixIngredients()
    {
        Debug.Log("Mixing Ingredients");
        if(bottle != null && ingredient != null)
        {
            bottle.AddIngredient(ingredient);
            ClearIngredient();
        }
        isOccupied = true;
        OnBrewing.Invoke();
        for(int i = 0; i < timeTaken; i++)
        {
            time = timeTaken - i;
            OnTimerTick.Invoke(time);
            yield return new WaitForSeconds(1);
        }
        OnBrewingComplete.Invoke();
        OnTimerTick.Invoke(0);
        isOccupied = false;
    }

    public BottleModel InteractCauldron()
    {
        if (isOccupied)
        {
            return null;
        }
        if(ingredient == null && bottle != null)
        {
            return TakeBottle();
        }
        return null;
    }
    public bool SetIngredient(IngredientModel ingredient)
    {
        if(this.ingredient != null)
        {
            return false;
        }
        this.ingredient = ingredient;
        OnIngredientChange.Invoke();
        return true;
    }

    public bool SetBottle(BottleModel bottle)
    {
        if(this.bottle != null)
        {
            return false;
        }
        this.bottle = bottle; 
        OnBottleChange.Invoke();
        return true;
    }
}