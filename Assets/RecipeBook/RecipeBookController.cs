using System;
using UnityEngine;
public class RecipeBookController : MonoBehaviour, IStation
{

    public static event Action OnRecipeBookInteracted;

    [SerializeField]
    private GameObject highlight;

    public void Highlight()
    {
        highlight.SetActive(true);
    }

    public void InteractStation(PlayerHandController playerHandController)
    {
        OnRecipeBookInteracted?.Invoke();
    }

    public void RemoveHighlight()
    {
        highlight.SetActive(false);
    }
}