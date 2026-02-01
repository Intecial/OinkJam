using UnityEngine;

public class SupplierController : MonoBehaviour, IStation{

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
            pickUp.PickUp(playerHandController);
        }

    }
}