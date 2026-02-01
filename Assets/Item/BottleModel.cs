
using System.Collections.Generic;

public class BottleModel : ItemModel
{

    private List<IngredientData> ingredients;
    public BottleModel(ItemData itemData) : base(itemData)
    {
        ingredients = new List<IngredientData>();
    }
}