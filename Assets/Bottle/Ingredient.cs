using UnityEngine;

public class Ingredient : MonoBehaviour, IPickUp
{
    [SerializeField]
    private ItemConfig itemConfig;

    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private BoxCollider2D box;

    private IngredientModel ingredientModel;

    public IngredientModel Model => ingredientModel;

    public void Initialize(ItemConfig itemConfig)
    {
        this.itemConfig = itemConfig;
        sr.sprite = itemConfig.sprite;
        
    }
    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
        ingredientModel = new IngredientModel();
        Initialize(this.itemConfig);
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