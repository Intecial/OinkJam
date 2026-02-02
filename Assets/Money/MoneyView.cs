using UnityEngine;
using UnityEngine.UIElements;

public class MoneyView : MonoBehaviour
{
    private VisualElement ui;
    


    void Awake()
    {
        MoneyController.OnMoneyUpdated += UpdateMoney;
        ui = GetComponent<UIDocument>().rootVisualElement;
    }

    void OnDestroy()
    {
        MoneyController.OnMoneyUpdated -= UpdateMoney;
    }
    private void UpdateMoney(int amount)
    {
        ui.Q<Label>("Money").text = amount.ToString();
    }
}
