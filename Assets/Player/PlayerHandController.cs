using UnityEngine;

public class PlayerHandController : MonoBehaviour
{
    [SerializeField]
    private GameObject itemSlot;

    private IItem pickedUpItem;

    void OnEnable()
    {
        ItemController.onItemInteract += PickUpItem;
        StationController.OnStationInteract += StationInteract;
    }

    void OnDisable()
    {
        ItemController.onItemInteract -= PickUpItem;
        StationController.OnStationInteract -= StationInteract;
    }

    public void StationInteract(IStation stationController)
    {
        stationController.InitiateInteraction(this);
    }


    public void PickUpItem(IItem item)
    {
        if (isHoldingItem())
        {
            return;
        }
        item.PickUp(this);
        pickedUpItem = item;
    }
    public bool isHoldingItem()
    {
        return itemSlot.transform.childCount > 0;
    }

    public GameObject GetHeldItem()
    {
        return itemSlot.transform.GetChild(0).gameObject;
    }

    public void SetHeldItem(GameObject gameObject)
    {
        
        gameObject.transform.parent = itemSlot.transform;
        gameObject.transform.position = itemSlot.transform.position;
        
        // Rigidbody2D itemRb = item.GetComponent<Rigidbody2D>();
        // itemRb.constraints = RigidbodyConstraints2D.FreezeAll;
    }
    
    public void DropItem()
    {
        GameObject item = GetHeldItem();
        item.transform.parent = null;
        
        pickedUpItem.GetGameObject().GetComponent<ItemController>().Drop(this);
        pickedUpItem = null;
        // Rigidbody2D itemRb = item.GetComponent<Rigidbody2D>();
        // itemRb.constraints = RigidbodyConstraints2D.None;
        
    }
}
