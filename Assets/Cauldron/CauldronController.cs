using System;
using UnityEngine;

public class CauldronController : MonoBehaviour, IStation
{

    // Bottle
    [SerializeField]
    private GameObject bottlePrefab;
    private CauldronModel cauldronModel;

    [SerializeField]
    private SpriteRenderer bottleRenderer;

    [SerializeField]
    private SpriteRenderer ingredientRenderer;

    private bool isMixing = false;

    void Awake()
    {
        cauldronModel = new CauldronModel();
        CauldronModel.OnBottleChange += OnBottleChange;
        CauldronModel.OnIngredientChange += OnIngredientChange;
    }

    private void OnDestroy() {
        CauldronModel.OnBottleChange -= OnBottleChange;
        CauldronModel.OnIngredientChange -= OnIngredientChange;
    }

    private void OnBottleChange() {
        if(cauldronModel.bottle != null){
            bottleRenderer.sprite = cauldronModel.bottle.Config.sprite;
        }
        else {
            bottleRenderer.sprite = null;
        }
    }

    private void OnIngredientChange(){
        if(cauldronModel.ingredient != null){
            ingredientRenderer.sprite = cauldronModel.ingredient.Config.sprite;
        } else {
            ingredientRenderer.sprite = null;
        }
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
                GameObject bottleObj = Instantiate(bottlePrefab, this.transform.position, Quaternion.identity);
                bottleObj.GetComponent<Bottle>().SetBottleModel(bottleModel);
                bottleObj.GetComponent<IPickUp>().PickUp(playerHandController);
                // bottleRenderer.sprite = bottleModel.GetSprite();
                // ingredientRenderer.sprite = bottleModel.GetSprite();
            }
        }
    }
}
