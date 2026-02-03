using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewIngredient", menuName = "Ingredient Config")]
public class IngredientConfig : ItemConfig
{
    public IngredientEffect effect;

    public List<EffectConfig> effectConfigs = new List<EffectConfig>();
}

public enum IngredientEffect
{
    Healing,
    Poison,
    Speed,
    Strength
}