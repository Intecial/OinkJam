using UnityEngine;
using UnityEngine.UIElements;

public class InteractUI : MonoBehaviour
{
    private VisualElement ui;

    void Awake()
    {
        ui = GetComponent<UIDocument>().rootVisualElement;
    }

    void Start()
    {
        Hide();
    }
    void OnEnable()
    {
        RaycastHandler.OnInteractableHit += CheckInteractable;
    }

    private void CheckInteractable(Interactable interactable)
    {
        if(interactable)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    private void Show()
    {
        ui.style.display = DisplayStyle.Flex;
    }

    private void Hide()
    {
        ui.style.display = DisplayStyle.None;
    }
}
