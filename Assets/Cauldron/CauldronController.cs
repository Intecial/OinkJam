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
    private GameObject highlight;

    [SerializeField]
    private AudioSource source;

    [SerializeField]
    private AudioClip brewingClip;

    [SerializeField]
    private AudioClip cauldronCompleteDing;

    [SerializeField]
    private GameObject bottleGo;

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

    private void OnBottleChange(BottleModel bottleModel) {
        if(cauldronModel.bottle != null){
            GameObject bottle = Instantiate(bottlePrefab, bottleGo.transform.position, Quaternion.identity, bottleGo.transform);
            bottle.GetComponent<Bottle>().DisablePhysics();
            bottle.GetComponent<Bottle>().SetBottleModel(bottleModel, bottleModel.bottleConfig);
        }
        else {
            foreach (Transform child in bottleGo.transform) {
                Destroy(child.gameObject);
            }
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
                if(cauldronModel.bottle != null && cauldronModel.ingredient != null)
                {
                    
                    StartCoroutine(cauldronModel.MixIngredients());
                }
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

    private void PlayPickUp(BottleModel bottleModel)
    {
        source.clip = pickUpBottle;
        source.time = 0.55f;
        source.Play();
    }

    private void PlayCompleteDing(BottleModel bottleModel)
    {
        bottleGo.GetComponentInChildren<Bottle>().SetBottleModel(bottleModel, bottleModel.bottleConfig);
        source.PlayOneShot(cauldronCompleteDing);
    }
    
    private void PlayIngredientPickUp()
    {
        source.clip = pickUpIngredient;
        source.time = 0.18f;
        source.Play();
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
