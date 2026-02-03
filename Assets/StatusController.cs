using UnityEngine;

public class StatusController : MonoBehaviour, IStation
{
    public void InteractStation(PlayerHandController playerHandController)
    {
        if (playerHandController.isHoldingItem())
        {
            GameObject heldItem = playerHandController.GetHeldItem();
            BottleModel bottleModel = heldItem.GetComponent<Bottle>().Model;
            Debug.Log(bottleModel.GetEffects().Count);
            foreach (EffectModel effect in bottleModel.GetEffects())
            {
                Debug.Log("Effect: "+ effect.ToString());
            }
            Debug.Log(heldItem.GetComponent<Bottle>().Model.ToString());
        }

    }
}
