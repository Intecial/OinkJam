

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CustomerView : MonoBehaviour
{
    private VisualElement ui;
    private Button closeButton;

    [SerializeField]
    private VisualTreeAsset itemTemplate;

    private void Awake()
    {
        ui = GetComponent<UIDocument>().rootVisualElement;
        CustomerStation.OnCustomerInteracted += HandleCustomerInteracted;
    }

    void OnEnable()
    {
        closeButton = ui.Q<Button>("CloseButton");
        closeButton.clicked += Hide;
    }

    void Start()
    {
        Hide();
    }

    void Show()
    {
        ui.style.display = DisplayStyle.Flex;
    }

    void Hide()
    {
        ui.style.display = DisplayStyle.None;
    }
    void OnDestroy()
    {
        CustomerStation.OnCustomerInteracted -= HandleCustomerInteracted;
    }

    private void HandleCustomerInteracted(CustomerModel customerModel)
    {
        BottleModel bottleModel = customerModel.Bottle;

        ui.Q<Label>("CustomerName").text = customerModel.Config.name;
        
        ui.Q<Label>("CustomerPrice").text = customerModel.totalPay.ToString();


        VisualElement itemContainer = ui.Q<VisualElement>("ItemContainer");
        itemContainer.Clear();
        CreateItemRow(bottleModel.Config, itemContainer);

        List<IngredientModel> ingredients = bottleModel.GetIngredients();
        foreach (IngredientModel ingredient in ingredients)
        {
            CreateItemRow(ingredient.Config, itemContainer);
        }

        Show();
    }

    private void CreateItemRow(ItemConfig itemConfig, VisualElement itemContainer) {
        VisualElement itemRow = itemTemplate.CloneTree();
        itemRow.Q<Label>("ItemName").text = itemConfig.name;
        itemRow.Q<Image>("ItemSprite").sprite = itemConfig.sprite;
        itemContainer.Add(itemRow);
    }


}