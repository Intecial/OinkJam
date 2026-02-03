
using UnityEngine;
public class BottleRandomization
{
    private BottleConfig[] bottleConfigs;

    private IngredientConfig[] ingredientConfigs;

    private EffectConfig[] effectConfigs;

    public BottleRandomization()
    {
        bottleConfigs = Resources.LoadAll<BottleConfig>("Bottles");
        ingredientConfigs = Resources.LoadAll<IngredientConfig>("Ingredients");
        effectConfigs = Resources.LoadAll<EffectConfig>("Effects");
    }

    public BottleModel RandomizeBottle(int numOfIngredients)
    {
        int totalCost = 0;
        BottleConfig bottleConfig = bottleConfigs[Random.Range(0, bottleConfigs.Length)];
        BottleModel bottleModel = new BottleModel(bottleConfig);
        totalCost += bottleConfig.cost;
        
        for (int i = 0; i < numOfIngredients; i++)
        {
            IngredientConfig ingredientConfig = ingredientConfigs[Random.Range(0, ingredientConfigs.Length)];
            bottleModel.AddIngredient(new IngredientModel(ingredientConfig));
            totalCost += ingredientConfig.cost;
        }
        bottleModel.SetTotalCost(totalCost);
        return bottleModel;
    }
    
}