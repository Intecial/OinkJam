using System;
using TMPro;
using UnityEngine;

public class CauldronController : MonoBehaviour, IStation
{

    // Bottle
    [SerializeField]
    private GameObject bottlePrefab;
    private CauldronModel cauldronModel;

    [SerializeField]
    private AudioSource source;

    [SerializeField]
    private AudioClip brewingClip;

    [SerializeField]
    private AudioClip cauldronCompleteDing;

    [SerializeField]
    private SpriteRenderer bottleRenderer;

    [SerializeField]
    private SpriteRenderer ingredientRenderer;

    [SerializeField]
    private AudioClip pickUpBottle;

    [SerializeField]
    private AudioClip pickUpIngredient;

    [SerializeField]
    private TextMeshPro timeText;

    private bool isMixing = false;

    void Awake()
    {
        cauldronModel = new CauldronModel();
        cauldronModel.OnBottleChange += OnBottleChange;
        cauldronModel.OnBottleChange += PlayPickUp;
        cauldronModel.OnIngredientChange += OnIngredientChange;
        cauldronModel.OnTimerTick += UpdateTimerLabel;
        cauldronModel.OnBrewing += PlayBrewing;
        cauldronModel.OnBottlePickUp += PlayPickUp;
        cauldronModel.OnBrewingComplete += PlayCompleteDing;
        cauldronModel.OnIngredientChange += PlayIngredientPickUp;
        UpdateTimerLabel(0);
    }

    private void OnDestroy() {
        cauldronModel.OnBottleChange -= OnBottleChange;
        cauldronModel.OnBottleChange -= PlayPickUp;
        cauldronModel.OnIngredientChange -= OnIngredientChange;
        cauldronModel.OnIngredientChange -= PlayIngredientPickUp;
        cauldronModel.OnTimerTick -= UpdateTimerLabel;
        cauldronModel.OnBrewing -= PlayBrewing;
        cauldronModel.OnBottlePickUp -= PlayPickUp;
        cauldronModel.OnBrewingComplete -= PlayCompleteDing;
    }

    private void OnBottleChange() {
        if(cauldronModel.bottle != null){
            bottleRenderer.sprite = cauldronModel.bottle.Config.sprite;
        }
        else {
            bottleRenderer.sprite = null;
        }
    }

    private void OnIngredientChange(){
        if(cauldronModel.ingredient != null){
            ingredientRenderer.sprite = cauldronModel.ingredient.Config.sprite;
        } else {
            ingredientRenderer.sprite = null;
        }
    }

    public void InteractStation(PlayerHandController playerHandController)
    {
        if(cauldronModel.isOccupied) return;
        Debug.Log("IsInteracting :" + playerHandController.isHoldingItem());
        if (playerHandController.isHoldingItem())
        {
            GameObject heldItem = playerHandController.GetHeldItem();
            
            bool isBottle = heldItem.TryGetComponent<Bottle>(out var bottle);
            bool isIngredient = heldItem.TryGetComponent<Ingredient>(out var ingredient);
            if (isBottle)
            {
                if (cauldronModel.SetBottle(bottle.Model))
                {
                    playerHandController.ConsumeObject();
                }
            } else if (isIngredient)
            {
               if(cauldronModel.SetIngredient(ingredient.Model)) {
                    playerHandController.ConsumeObject();
               }
            }
    } else
        {
            BottleModel bottleModel = cauldronModel.InteractCauldron();
            if (bottleModel != null)
            {
                GameObject bottleObj = Instantiate(bottlePrefab, this.transform.position, Quaternion.identity);
                bottleObj.GetComponent<Bottle>().SetBottleModel(bottleModel, bottleModel.bottleConfig);
                bottleObj.GetComponent<IPickUp>().PickUp(playerHandController);
                // bottleRenderer.sprite = bottleModel.GetSprite();
                // ingredientRenderer.sprite = bottleModel.GetSprite();
            } else
            {
                StartCoroutine(cauldronModel.MixIngredients());
            }
        }
    }

    private void UpdateTimerLabel(int time)
    {
        if(time == 0)
        {
            timeText.text = "";
            return;
        }
        timeText.text = time.ToString();
    }

    private void PlayBrewing()
    {
        source.PlayOneShot(brewingClip);
    }

    private void PlayPickUp()
    {
        source.clip = pickUpBottle;
        source.time = 0.55f;
        source.Play();
    }

    private void PlayCompleteDing()
    {
        source.PlayOneShot(cauldronCompleteDing);
    }
    
    private void PlayIngredientPickUp()
    {
        source.clip = pickUpIngredient;
        source.time = 0.18f;
        source.Play();
    }
}
