
using UnityEngine;
public class BottleRandomization
{
    private ItemConfig[] bottleConfigs;

    private ItemConfig[] ingredientConfigs;

    public BottleRandomization()
    {
        bottleConfigs = Resources.LoadAll<ItemConfig>("Bottles");
        ingredientConfigs = Resources.LoadAll<ItemConfig>("Ingredients");
    }

    public BottleModel RandomizeBottle(int numOfIngredients)
    {
        int totalCost = 0;
        ItemConfig bottleConfig = bottleConfigs[Random.Range(0, bottleConfigs.Length)];
        BottleModel bottleModel = new BottleModel(bottleConfig);
        totalCost += bottleConfig.cost;
        
        for (int i = 0; i < numOfIngredients; i++)
        {
            ItemConfig ingredientConfig = ingredientConfigs[Random.Range(0, ingredientConfigs.Length)];
            bottleModel.AddIngredient(new IngredientModel(ingredientConfig));
            totalCost += ingredientConfig.cost;
        }
        bottleModel.SetTotalCost(totalCost);
        return bottleModel;
    }
    
}