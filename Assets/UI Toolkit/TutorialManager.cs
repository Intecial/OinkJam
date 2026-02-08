using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class TutorialManager : MonoBehaviour
{
    private VisualElement ui;
    private Button nextButton;


    private List<VisualElement> page = new List<VisualElement>();
    private int index;
    void OnEnable()
    {
        nextButton = ui.Q<Button>("NextButton");
        nextButton.clicked += nextPage;
    }

    void Awake()
    {
        ui = GetComponent<UIDocument>().rootVisualElement;
        index = 0;

        page.Add(ui.Q<VisualElement>("First"));
        page.Add(ui.Q<VisualElement>("Second"));

    }
    
    
    private void nextPage()
    {
        page[index].style.display = DisplayStyle.None;
        index += 1;
        if(index >= page.Count)
        {
            SceneManager.LoadScene("SampleScene");
        }
        page[index].style.display = DisplayStyle.Flex;
        
    }
}
