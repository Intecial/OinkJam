using System;
using UnityEngine;

public class CauldronController : MonoBehaviour, IStation
{
    // Bottle
    private CauldronModel cauldronModel;

    private bool isMixing = false;
    // Ingredient
    public void InitiateInteraction(PlayerHandController playerHandController)
    {
        if (playerHandController.isHoldingItem())
        {
            // GameObject gameObject = playerHandController.GetHeldItem();
            // ItemController itemController = gameObject.GetComponent<ItemController>();
            // if(itemController.itemTypes == ItemTypes.BOTTLE)
            // {
            //     cauldronModel.SetBottle(itemController.GetItemData());
            // } else if (itemController.itemTypes == ItemTypes.INGREDIENT)
            // {
            //     cauldronModel.SetIngredient(itemController.GetItemData());
            // }
        }
        
    }
}
