
using System.Collections.Generic;

public class BottleModel
{
    private ItemConfig itemConfig;

    public ItemConfig Config => itemConfig;
    private int maxIngredients = 3;
    private List<IngredientModel> ingredients;
    
    public BottleModel(BottleModel bottleModel)
    {
        this.ingredients = new List<IngredientModel>(bottleModel.ingredients);
        this.itemConfig = bottleModel.Config;
    }

    public BottleModel(ItemConfig itemConfig)
    {
        this.ingredients = new List<IngredientModel>();
        this.itemConfig = itemConfig;
    }

    public bool AddIngredient(IngredientModel ingredient)
    {
        if(maxIngredients <= this.ingredients.Count)
        {
            return false;
        }
        
        this.ingredients.Add(ingredient);
        return true;
    }

    public override string ToString()
    {
        string ret = "";
        foreach (IngredientModel ingredient in this.ingredients)
        {
            ret += ingredient.ToString() + "\n";
        }
        return ret;
    }
}