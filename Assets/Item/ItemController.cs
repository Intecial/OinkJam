using System;
using UnityEngine;

public class ItemController : Interactable, IItem
{
    [SerializeField] private ItemData itemData;
    
    private ItemModel itemModel;
    public static event Action<IItem> onItemInteract;

    public ItemModel Model => itemModel;

    [SerializeField]
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private BoxCollider2D box;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
        itemModel = new ItemModel(itemData);
        spriteRenderer.sprite = itemModel.Data.sprite;
        // spriteRenderer.sprite = itemData.sprite;
        // itemTypes = itemData.itemType;
        // Initialize the view with this Model
    }

    public override void Interact()
    {
        onItemInteract.Invoke(this);
        
    }

    public void PickUp(PlayerHandController playerHandController)
    {
        playerHandController.SetHeldItem(this.gameObject);
        this.DisableInteraction();

        // Stop Collider & RigidBody
        rb.simulated = false;
        box.enabled = true;
    }

    public void Drop(PlayerHandController playerHandController)
    {
        Debug.Log("Dropped!");
        // playerHandController.DropItem();
        this.EnableInteraction();
        
        //  Resume Collider & RigidBody
        rb.simulated = true;
        box.enabled = true;
    }

    public GameObject GetGameObject()
    {
        return this.gameObject;
    }

    public ItemData GetItemData()
    {
        return itemModel.Data;
    }
}
