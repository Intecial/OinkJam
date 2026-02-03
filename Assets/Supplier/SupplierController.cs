using UnityEngine;

public class SupplierController : MonoBehaviour, IStation{

    [SerializeField] private ItemConfig itemToSpawn;
    [SerializeField] private GameObject bottlePrefab;
    [SerializeField] private GameObject ingredientPrefab;

    [SerializeField]
    private SpriteRenderer bottleRenderer;

    void Awake()
    {
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
            } else
            {
                itemObj = Instantiate(ingredientPrefab, this.transform.position, Quaternion.identity);
                Ingredient ingredient = itemObj.GetComponent<Ingredient>();
                ingredient.Initialize(itemToSpawn as IngredientConfig);
            }
            bool hasPickUp = itemObj.TryGetComponent<IPickUp>(out var pickUp);
            if (hasPickUp)
            {
                    pickUp.PickUp(playerHandController);
            
            }
        }
    }
}