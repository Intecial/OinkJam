using System.Collections.Generic;

public class CustomerModel{

    private BottleModel requestedBottle;

    public CustomerModel(BottleModel requestedBottle){
        this.requestedBottle = requestedBottle;
    }

    public bool GiveBottle(BottleModel bottleModel){
        List<string> ingredients = GetBottleIngredientsNames(bottleModel);
        List<string> requestedIngredients = GetBottleIngredientsNames(requestedBottle);
        foreach (string requestedIngredient in requestedIngredients){
            if(ingredients.Contains(requestedIngredient) == false){
                return false;
            }
        }
        return true;
    }

    public List<string> GetBottleIngredientsNames(BottleModel bottleModel){
        List<string> ret = new List<string>();
        foreach (IngredientModel ingredient in bottleModel.GetIngredients()){
            ret.Add(ingredient.GetName());
        }
        return ret;
    }
}