using UnityEngine;

public class PlayerHandController : MonoBehaviour
{
    [SerializeField]
    private GameObject itemSlot;

    private IPickUp heldItem;



    public void StationInteract(IStation stationController)
    {
        stationController.InteractStation(this);
    }

    public void PickUpItem(IPickUp pickUpItem)
    {
        if (isHoldingItem())
        {
            return;
        }
        SetHeldItem(pickUpItem.GetGameObject());
        heldItem = pickUpItem;
    }


    public bool isHoldingItem()
    {
        return itemSlot.transform.childCount > 0;
    }

    public void SetHeldItem(GameObject gameObject)
    {
        
        gameObject.transform.parent = itemSlot.transform;
        gameObject.transform.position = itemSlot.transform.position;
    }
    
    public void DropItem()
    {
        GameObject item = heldItem.GetGameObject();
        item.transform.parent = null;
        heldItem.Drop(this);
        heldItem = null;
        
    }

    public GameObject GetHeldItem()
    {
        return heldItem.GetGameObject();
    }

    public void ConsumeObject()
    {
        if (isHoldingItem())
        {
            GameObject item = heldItem.GetGameObject();
            Destroy(item);
            heldItem = null;
        }
    }
}
