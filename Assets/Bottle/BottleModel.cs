
using System.Collections.Generic;
// using System.Diagnostics;
using System.Linq;
using UnityEngine;

public class BottleModel
{
    private ItemConfig itemConfig;

    public ItemConfig Config => itemConfig;

    public BottleConfig bottleConfig;
    public int maxIngredients = 10;
    private List<IngredientModel> ingredients;

    private List<EffectModel> effects;

    private int totalCost;

    public List<IngredientModel> GetIngredients() => this.ingredients;    
    public BottleModel(BottleModel bottleModel)
    {
        this.ingredients = new List<IngredientModel>(bottleModel.ingredients);
        this.itemConfig = bottleModel.Config;
        this.bottleConfig = bottleModel.bottleConfig;
        Debug.Log(bottleModel.effects.Count);
        this.effects = new List<EffectModel>(bottleModel.effects);
    }

    public BottleModel(BottleConfig itemConfig)
    {
        this.ingredients = new List<IngredientModel>();
        this.itemConfig = itemConfig;
        this.bottleConfig = itemConfig;
        this.effects = new List<EffectModel>();
    }

    public bool AddIngredient(IngredientModel ingredient)
    {
        if(maxIngredients <= this.ingredients.Count)
        {
            return false;
        }
        
        this.ingredients.Add(ingredient);


        foreach(EffectConfig effect in ingredient.ingredientConfig.effectConfigs){
            Debug.Log(effect.EffectName);
            bool hasReaction = isReacting(effect);
            Debug.Log("Has Reaction? : " + (hasReaction == false));
            if(hasReaction == false)
            {
                EffectModel newEffect = new EffectModel(effect);
                this.effects.Add(newEffect);
                
            }
        }
        Debug.Log(this.effects.Count);
        return true;
    }

    public bool isReacting(EffectConfig effectConfig)
    {
        bool isApplied = false;
        List<EffectModel> modelCopy = new List<EffectModel>(this.effects);
        foreach(EffectModel effectModel in effects)
        {
            EffectModel newEffectModel = effectModel.ApplyEffect(effectConfig);
            if(newEffectModel != null)
            {
                modelCopy.Remove(effectModel);
                modelCopy.Add(newEffectModel);
                isApplied = true;
            }
        }
        this.effects = modelCopy;
        return isApplied;
        
    }

    public override string ToString()
    {
        string ret = "";
        foreach (EffectModel effectModel in this.effects)
        {
            ret += effectModel.ToString() + "\n";
        }
        return ret;
    }

    public void SetTotalCost(int totalCost)
    {
        this.totalCost = totalCost;
    }

    public int GetTotalCost() => this.totalCost;

    public List<EffectModel> GetEffects() => this.effects;  
}