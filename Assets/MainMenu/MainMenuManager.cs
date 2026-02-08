using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public VisualElement ui;

    private Button startButton;
    private Button tutorialButton;

    void Awake()
    {
        ui = GetComponent<UIDocument>().rootVisualElement;
    }

    void OnEnable()
    {
        
        startButton = ui.Q<Button>("PlayButton");
        tutorialButton = ui.Q<Button>("TutorialButton");
        startButton.clicked += OnStartButtonClicked;
        tutorialButton.clicked += OnTutorialButtonClicked;
    }

    public void OnStartButtonClicked()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void OnTutorialButtonClicked()
    {
        SceneManager.LoadScene("TutorialScene");
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
