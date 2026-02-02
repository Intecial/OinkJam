using System.Collections.Generic;
using UnityEngine;
public class CustomerModel{

    private CustomerConfig customerConfig;

    public CustomerConfig Config => customerConfig;
    private BottleModel requestedBottle;

    public BottleModel Bottle => requestedBottle;

    public int totalPay { get; private set; }

    public CustomerModel(BottleModel requestedBottle, CustomerConfig customerConfig){
        this.requestedBottle = requestedBottle;
        this.customerConfig = customerConfig;
        totalPay = 0;
        int pay = requestedBottle.GetTotalCost();
        int profitMargin = customerConfig.profitMargin;
        totalPay = Mathf.RoundToInt((pay * (profitMargin / 100f)) + pay);
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