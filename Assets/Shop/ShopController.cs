using UnityEngine;
using UnityEngine.UIElements;

public class ShopController : MonoBehaviour
{
    private VisualElement ui;

    void Awake()
    {
        ui = GetComponent<UIDocument>().rootVisualElement;
    }

    public void toggleShopUI()
    {
        ui.style.display = ui.style.display == DisplayStyle.None ? DisplayStyle.Flex : DisplayStyle.None;
    }
}
