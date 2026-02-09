using UnityEngine;
using UnityEngine.UIElements;

public class InteractUI : MonoBehaviour
{
    private VisualElement ui;
    private IStation station;

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
            if(interactable.gameObject.TryGetComponent<IStation>(out var station))
            {
                station.Highlight();
                this.station = station;
            }
            Show();
        }
        else
        {
            if(station != null)
            {
                station.RemoveHighlight();
                station = null;
                
            }
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
