using System;
using UnityEngine;

public class StatusController : MonoBehaviour, IStation
{
    public static event Action<BottleModel> OnStatusInteracted;
    public void InteractStation(PlayerHandController playerHandController)
    {
        if (playerHandController.isHoldingItem())
        {
            GameObject heldItem = playerHandController.GetHeldItem();
            BottleModel bottleModel = heldItem.GetComponent<Bottle>().Model;
            OnStatusInteracted.Invoke(bottleModel);
        }

    }
}
