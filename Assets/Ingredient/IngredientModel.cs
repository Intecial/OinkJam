public class IngredientModel
{
    private ItemConfig itemConfig;
    public ItemConfig Config => itemConfig;

    public IngredientModel(ItemConfig itemConfig)
    {
        this.itemConfig = itemConfig;
        
    }
        

    public string GetName(){
        return itemConfig.name;
    }

    public override string ToString()
    {
        return " Ingredient: " + this.itemConfig.name + " ";
    }
}