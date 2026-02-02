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
        bottleModel = new BottleModel(itemConfig);
        Initialize(this.itemConfig);
    }

    public void Initialize(ItemConfig itemConfig)
    {
        this.itemConfig = itemConfig;
        sr.sprite = itemConfig.sprite;
        bottleModel = new BottleModel(itemConfig);
        
    }

    public void SetBottleModel(BottleModel bottleModel)
    {
        this.bottleModel = new BottleModel(bottleModel);
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