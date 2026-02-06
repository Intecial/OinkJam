using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class StatusView : MonoBehaviour
{
    private VisualElement ui;
    private Button closeButton;

    private VisualElement ingredientContainer;
    private VisualElement effectContainer;
    private VisualElement bottleContainer;
    
    [SerializeField]
    private VisualTreeAsset itemIngredientRow;
    
    
    private void Awake()
    {
        ui = GetComponent<UIDocument>().rootVisualElement;
        closeButton = ui.Q<Button>("CloseButton");
        closeButton.clicked += Hide;

        bottleContainer = ui.Q<VisualElement>("BottleInfo");
        ingredientContainer = ui.Q<VisualElement>("IngredientList");
        effectContainer = ui.Q<VisualElement>("EffectsList");

    }

    void OnEnable()
    {
        StatusController.OnStatusInteracted += Show;
    }

    void OnDisable()
    {
        StatusController.OnStatusInteracted -= Show;
    }


    void Start()
    {
        Hide();
    }

    void Show(BottleModel bottleModel)
    {
        ui.style.display = DisplayStyle.Flex;
        createBottleModelView(bottleModel);


    }

    private void createBottleModelView(BottleModel bottleModel)
    {
        BottleConfig bottleConfig = bottleModel.bottleConfig;
        List<IngredientConfig> ingredients = bottleModel.GetIngredients().ConvertAll(x => x.ingredientConfig);
        List<EffectConfig> effects = bottleModel.GetEffects().ConvertAll(x => x.Config);
        bottleContainer.Clear();
        ingredientContainer.Clear();
        effectContainer.Clear();

        CreateBottleRow(bottleConfig, bottleContainer);
        foreach (IngredientConfig ingredient in ingredients)
        {
            CreateIngredientRow(ingredient, ingredientContainer);
        }
        foreach (EffectConfig effect in effects)
        {
            CreateEffectRow(effect, effectContainer);
        }

        
        
    }
        void Hide()
    {
        ui.style.display = DisplayStyle.None;
    }

    private void CreateEffectRow(EffectConfig effectConfig, VisualElement itemContainer)
    {
        VisualElement itemRow = itemIngredientRow.CloneTree();
        itemRow.Q<Label>("ItemName").text = effectConfig.EffectName;
        // itemRow.Q<Image>("ItemSprite").sprite = itemConfig.sprite;
        itemContainer.Add(itemRow);
        
    }

    private void CreateBottleRow(BottleConfig itemConfig, VisualElement itemContainer) {
        VisualElement itemRow = itemIngredientRow.CloneTree();
        itemRow.Q<Label>("ItemName").text = itemConfig.name;
        itemRow.Q<Image>("ItemSprite").sprite = itemConfig.sprite;
        itemContainer.Add(itemRow);
    }

     private void CreateIngredientRow(IngredientConfig itemConfig, VisualElement itemContainer) {
        VisualElement itemRow = itemIngredientRow.CloneTree();
        itemRow.Q<Label>("ItemName").text = itemConfig.name;
        itemRow.Q<Image>("ItemSprite").sprite = itemConfig.sprite;
        itemContainer.Add(itemRow);
    }
}
