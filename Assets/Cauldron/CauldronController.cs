using System;
using UnityEngine;

public class CauldronController : MonoBehaviour, IStation
{
    // Bottle
    private CauldronModel cauldronModel;

    [SerializeField]
    private SpriteRenderer bottleRenderer;

    [SerializeField]
    private SpriteRenderer ingredientRenderer;

    private bool isMixing = false;

    void Awake()
    {
        cauldronModel = new CauldronModel();
    }

    public void InteractStation(PlayerHandController playerHandController)
    {
        Debug.Log("IsInteracting :" + playerHandController.isHoldingItem());
        if (playerHandController.isHoldingItem())
        {
            GameObject heldItem = playerHandController.GetHeldItem();
            
            bool isBottle = heldItem.TryGetComponent<Bottle>(out var bottle);
            bool isIngredient = heldItem.TryGetComponent<Ingredient>(out var ingredient);
            if (isBottle)
            {
                cauldronModel.SetBottle(bottle.Model);
            } else if (isIngredient)
            {
                cauldronModel.SetIngredient(ingredient.Model);
            }
            playerHandController.ConsumeObject();
        } else
        {
            BottleModel bottleModel = cauldronModel.InteractCauldron();
            if (bottleModel != null)
            {
                // bottleRenderer.sprite = bottleModel.GetSprite();
                // ingredientRenderer.sprite = bottleModel.GetSprite();
            }
        }
    }
}
