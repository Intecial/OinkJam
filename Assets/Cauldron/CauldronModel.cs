using System;
using UnityEngine;

public class CauldronModel
{
    private ItemData bottle;

    private ItemData ingredient;


    public void SetBottle(ItemData bottle)
    {
        this.bottle = bottle;
        
    }

    public void SetIngredient(ItemData ingredient)
    {
        this.ingredient = ingredient;
    }
    public void GetMixResult()
    {
        
    }
}