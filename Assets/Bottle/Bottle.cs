using System.Collections.Generic;
using UnityEngine;

public class Bottle : MonoBehaviour, IPickUp
{
    [SerializeField]
    private BottleConfig itemConfig;
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
            Initialize(this.itemConfig);
        }
    }

    public void Initialize(BottleConfig itemConfig)
    {
        this.itemConfig = itemConfig;
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = itemConfig.sprite;
        bottleModel = new BottleModel(itemConfig);
        sr.sortingOrder = bottleModel.maxIngredients + 1;
        CreateColors(bottleModel.GetEffects());
        
    }

    public void SetBottleModel(BottleModel bottleModel, BottleConfig itemConfig)
    {
        this.bottleModel = new BottleModel(bottleModel);
        sr.sortingOrder = bottleModel.maxIngredients + 1;
        this.itemConfig = itemConfig;
        sr.sprite = itemConfig.sprite;
        CreateColors(bottleModel.GetEffects());
    }

    private void CreateColors(List<EffectModel> effects)
    {
        int index = 0;
        foreach (EffectModel effectModel in effects)
        {
            float opacity = 0.8f;
            if(index == 0)
            {
                opacity = 1f;
            }
           GameObject srGameObject = new GameObject("EffectSprite");
            srGameObject.transform.SetParent(this.transform);
            srGameObject.transform.position = this.transform.position;

            SpriteRenderer newSr = srGameObject.AddComponent<SpriteRenderer>();

            Color color = effectModel.Config.Color;
            newSr.color = new Color(color.r, color.g, color.b, opacity);
            newSr.sortingOrder = index;
            newSr.sprite = itemConfig.ColorSprite;
            index += 1;
        }
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

    public void DisablePhysics()
    {
        rb.simulated = false;
        box.enabled = false;
        
    }

    public void EnablePhysics()
    {
        rb.simulated = true;
        box.enabled = true;
    }
    
}