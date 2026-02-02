using System;
using UnityEngine;

public class CauldronModel
{
    public static event Action OnBottleChange;

    public static event Action OnIngredientChange;

    public BottleModel bottle { get; private set; }
    public IngredientModel ingredient { get; private set; }

    public BottleModel TakeBottle()
    {
        Debug.Log("Grab Bottle");
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

    public void MixIngredients()
    {
        Debug.Log("Mixing Ingredients");
        if(bottle != null && ingredient != null)
        {
            bottle.AddIngredient(ingredient);
            ClearIngredient();
        }
    }

    public BottleModel InteractCauldron()
    {
        if(ingredient == null)
        {
            return TakeBottle();
        }
        else
        {
            MixIngredients();
        }
        return null;
    }
    public void SetIngredient(IngredientModel ingredient)
    {
        this.ingredient = ingredient;
        OnIngredientChange.Invoke();
    }

    public void SetBottle(BottleModel bottle)
    {
        this.bottle = bottle; 
        OnBottleChange.Invoke();
    }
}