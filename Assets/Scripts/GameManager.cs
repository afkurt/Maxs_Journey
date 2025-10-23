using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public static Action StartCallBack;
    public static Action Quit;
    public static Action LevelCompletedCallBack;

    private void OnEnable()
    {
        
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void NextLevel()  //butona basýldýðýnda
    {
        UIManager.Instance.levelCompleteUI.SetActive(false);
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        Time.timeScale = 1f;
        SceneManager.LoadScene(nextScene);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    

}
