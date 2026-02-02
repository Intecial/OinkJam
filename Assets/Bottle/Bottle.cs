using UnityEngine;

public class Bottle : MonoBehaviour, IPickUp
{
    [SerializeField]
    private ItemConfig itemConfig;
    private BottleModel bottleModel;
    private Rigidbody2D rb;
    private BoxCollider2D box;
    private SpriteRenderer sr;

    public BottleModel Model => bottleModel;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
        if(this.itemConfig != null)
        {
            
            bottleModel = new BottleModel(this.itemConfig);
        }
        Initialize(this.itemConfig);
    }

    public void Initialize(ItemConfig itemConfig)
    {
        this.itemConfig = itemConfig;
        sr.sprite = itemConfig.sprite;
        bottleModel = new BottleModel(itemConfig);
        
    }

    public void SetBottleModel(BottleModel bottleModel, ItemConfig itemConfig)
    {
        this.bottleModel = new BottleModel(bottleModel);
        this.itemConfig = itemConfig;
        sr.sprite = itemConfig.sprite;
    }
    public void Drop(PlayerHandController playerHandController)
    {
        rb.simulated = true;
        box.enabled = true;
    }

    public GameObject GetGameObject()
    {
        return this.gameObject;
    }

    public void PickUp(PlayerHandController playerHandController)
    {
        playerHandController.PickUpItem(this);
        rb.simulated = false;
        box.enabled = false;
    }
    
}