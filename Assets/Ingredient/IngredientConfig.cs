using UnityEngine;

[CreateAssetMenu(fileName = "NewIngredient", menuName = "Ingredient Config")]
public class IngredientConfig : ItemConfig
{
    public IngredientEffect effect;
}

public enum IngredientEffect
{
    Healing,
    Poison,
    Speed,
    Strength
}