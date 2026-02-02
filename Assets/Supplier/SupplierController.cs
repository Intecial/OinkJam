using UnityEngine;

public class SupplierController : MonoBehaviour, IStation, ICostMoney{

    [SerializeField] private ItemConfig itemToSpawn;
    [SerializeField] private GameObject prefab;

    public void InteractStation(PlayerHandController playerHandController)
    {
        if (playerHandController.isHoldingItem())
        {
            return;
        }
        GameObject itemObj = Instantiate(prefab, this.transform.position, Quaternion.identity);
        bool hasPickUp = itemObj.TryGetComponent<IPickUp>(out var pickUp);
        if (hasPickUp)
        {
            MoneyController.TryDeduct(itemToSpawn.cost);
            pickUp.PickUp(playerHandController);
        }

    }
}