using UnityEngine;

[CreateAssetMenu(fileName = "NewIngredient", menuName = "Ingredient Data")]
public class IngredientData : ItemData
{
    public Color ingredientColor;
    public IngredientEffect effect;
}

public enum IngredientEffect
{
    Healing,
    Poison,
    Speed,
    Strength
}