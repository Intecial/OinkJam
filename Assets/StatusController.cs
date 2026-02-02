using UnityEngine;

public class StatusController : MonoBehaviour, IStation
{
    public void InteractStation(PlayerHandController playerHandController)
    {
        if (playerHandController.isHoldingItem())
        {
            GameObject heldItem = playerHandController.GetHeldItem();
            Debug.Log(heldItem.GetComponent<Bottle>().Model);
        }

    }
}
