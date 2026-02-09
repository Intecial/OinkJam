using UnityEngine;
using UnityEngine.UIElements;

public class InteractUI : MonoBehaviour
{
    private VisualElement ui;

    void Awake()
    {
        ui = GetComponent<UIDocument>().rootVisualElement;
    }

    void OnEnable()
    {
        RaycastHandler.OnInteractProximity += CheckInteractable;
    }

    void OnDestroy()
    {
        RaycastHandler.OnInteractProximity -= CheckInteractable;
    }

    void Start()
    {
        Hide();
    }

    private void CheckInteractable(Collider2D interactable)
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
