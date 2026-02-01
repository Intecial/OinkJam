
using System.Collections.Generic;

public class BottleModel
{
    private int maxIngredients = 3;
    private List<IngredientModel> ingredients;
    
    public BottleModel(BottleModel bottleModel)
    {
        this.ingredients = new List<IngredientModel>(bottleModel.ingredients);
    }

    public BottleModel()
    {
        this.ingredients = new List<IngredientModel>();
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
}