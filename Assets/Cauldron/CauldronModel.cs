using System;
using UnityEngine;

public class CauldronModel
{
    private BottleModel bottle;
    private IngredientModel ingredient;

    public BottleModel GetBottle()
    {
        Debug.Log("Grab Bottle");
        BottleModel bottleModelCopy = new BottleModel(bottle);
        this.bottle = null;
        return bottleModelCopy;
        
    }

    public void MixIngredients()
    {
        Debug.Log("Mixing Ingredients");
        if(bottle != null && ingredient != null)
        {
            bottle.AddIngredient(ingredient);
            ingredient = null;
        }
    }

    public void SetBottle(BottleModel bottle)
    {
        this.bottle = bottle; 
    }

    public BottleModel InteractCauldron()
    {
        if(ingredient == null)
        {
            return GetBottle();
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
    }
}