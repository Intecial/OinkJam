using System.Collections.Generic;

public class IngredientModel
{
    private ItemConfig itemConfig;
    public ItemConfig Config => itemConfig;

    public IngredientConfig ingredientConfig;

    public IngredientModel(IngredientConfig itemConfig)
    {
        this.itemConfig = itemConfig as ItemConfig;
        this.ingredientConfig = itemConfig;
        
    }
        

    public string GetName(){
        return itemConfig.name;
    }

    public override string ToString()
    {
        return " Ingredient: " + this.itemConfig.name + " ";
    }
}