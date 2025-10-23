using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button startButton;
    public Button quitButton;

    private void Start()
    {
        startButton.onClick.AddListener(StartGame); 
        quitButton.onClick.AddListener(QuitGame);  
        
    }

    private void OnEnable()
    {
        GameManager.StartCallBack += StartGame;
        GameManager.Quit += QuitGame;
    }

    private void OnDisable()
    {
        GameManager.StartCallBack -= StartGame;
        GameManager.Quit -= QuitGame;
    }

    void StartGame()
    {
        SceneManager.LoadScene("Level 1");
    }

    void QuitGame()
    {
        Application.Quit();
    }
}
