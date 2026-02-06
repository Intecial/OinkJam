using System;
using UnityEngine;
public class RecipeBookController : MonoBehaviour, IStation
{

    public static event Action OnRecipeBookInteracted;

    public void InteractStation(PlayerHandController playerHandController)
    {
        OnRecipeBookInteracted?.Invoke();
    }
}