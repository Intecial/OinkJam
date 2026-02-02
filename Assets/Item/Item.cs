using UnityEngine;

public class Item : MonoBehaviour, IPickUp
{
    [SerializeField] private ItemConfig itemConfig;
    private Rigidbody2D rb;
    private BoxCollider2D box;
    private SpriteRenderer sr;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
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