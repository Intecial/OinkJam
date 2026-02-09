using UnityEngine;

public class SupplierController : MonoBehaviour, IStation{

    [SerializeField] private ItemConfig itemToSpawn;
    [SerializeField] private GameObject bottlePrefab;
    [SerializeField] private GameObject ingredientPrefab;


    [SerializeField]
    private GameObject highlight;

     private AudioSource source;

    [SerializeField] private AudioClip pickUpBottle;

    [SerializeField] private AudioClip pickUpIngredient;

    [SerializeField]
    private SpriteRenderer bottleRenderer;

    void Awake()
    {
        source = GetComponent<AudioSource>();
        bottleRenderer.sprite = itemToSpawn.sprite;
    }

    public void InteractStation(PlayerHandController playerHandController)
    {
        if (playerHandController.isHoldingItem())
        {
            return;
        }

        if (MoneyController.Instance.TryDeduct(itemToSpawn.cost))
        {
            GameObject itemObj = null;
            if(itemToSpawn.itemType == ItemTypes.BOTTLE)
            {
                itemObj = Instantiate(bottlePrefab, this.transform.position, Quaternion.identity);
                Bottle bottle = itemObj.GetComponent<Bottle>();
                bottle.Initialize(itemToSpawn as BottleConfig);
                source.clip = pickUpBottle;
                source.time = 0.55f;
                source.Play();
            } else
            {
                itemObj = Instantiate(ingredientPrefab, this.transform.position, Quaternion.identity);
                Ingredient ingredient = itemObj.GetComponent<Ingredient>();
                ingredient.Initialize(itemToSpawn as IngredientConfig);
                source.clip = pickUpIngredient;
                source.time = 0.18f;
                source.Play();
            }
            bool hasPickUp = itemObj.TryGetComponent<IPickUp>(out var pickUp);
            if (hasPickUp)
            {
                    pickUp.PickUp(playerHandController);
            
            }
        }
    }

    public void Highlight()
    {
        highlight.SetActive(true);
    }

    public void RemoveHighlight()
    {
        highlight.SetActive(false);
    }
}