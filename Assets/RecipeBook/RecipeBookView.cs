using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RecipeBookView : MonoBehaviour
{
    private VisualElement ui;
    private Button closeButton;
    private Button previousPage;

    private List<VisualElement> page;
 
    private Button nextPage;
    private int index = 0;
    private void Awake()
    {
        page = new List<VisualElement>();
        ui = GetComponent<UIDocument>().rootVisualElement;
        closeButton = ui.Q<Button>("CloseButton");
        previousPage = ui.Q<Button>("PrevPage");
        nextPage = ui.Q<Button>("NextButton");
        page.Add(ui.Q<VisualElement>("FirstPage"));
        page.Add(ui.Q<VisualElement>("SecondPage"));
        page.Add(ui.Q<VisualElement>("ThirdPage"));
        closeButton.clicked += Hide;
        index = 0;
        previousPage.clicked += PreviousPage;
        nextPage.clicked += NextPage;

    }

    void OnEnable()
    {
        RecipeBookController.OnRecipeBookInteracted += Show;
    }

    void OnDestroy()
    {
        RecipeBookController.OnRecipeBookInteracted -= Show;
    }

    private void NextPage()
    {
        page[index].style.display = DisplayStyle.None;
        index += 1;
        if(index >= page.Count)
        {
            index = page.Count - 1;
        }
        page[index].style.display = DisplayStyle.Flex;
    }

    private void PreviousPage()
    {
        page[index].style.display = DisplayStyle.None;
        index -= 1;
        if(index <= 0)
        {
            index = 0;
        }
        page[index].style.display = DisplayStyle.Flex;
    }

    void Start()
    {
        Hide();
    }

    void Show()
    {
        index = 0;
        ui.style.display = DisplayStyle.Flex;
        page[index].style.display = DisplayStyle.Flex;  
    }
        void Hide()
    {
        page[index].style.display = DisplayStyle.None;
        ui.style.display = DisplayStyle.None;
    }
}
