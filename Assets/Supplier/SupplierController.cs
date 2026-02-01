using UnityEngine;

public class SupplierController : MonoBehaviour, IStation{

    [SerializeField] private GameObject prefab;

    public void InitiateInteraction(PlayerHandController playerHandController)
    {
        GameObject itemObj = Instantiate(prefab, this.transform.position, Quaternion.identity);
        playerHandController.PickUpItem(itemObj.GetComponent<ItemController>());
    }
    // [SerializeField] private PlayerHandController playerHandController;

    // public override void Interact()
    // {
    //     GameObject itemObj = Instantiate(prefab, this.transform.position, Quaternion.identity);
    //     playerHandController.PickUpItem(itemObj);

    // }

    // public void StopInteraction()
    // {

    // }

    // public override void InitiateInteraction(PlayerHandController playerHandController)
    // {
    //     GameObject itemObj = Instantiate(prefab, this.transform.position, Quaternion.identity);
    //     playerHandController.PickUpItem(itemObj);
    // }
}