using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("UI Panelleri")]
    public GameObject gamePlayUI;
    public GameObject levelCompleteUI;
    public GameObject ending;
    public GameObject onDie;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); 
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        
    }

    public void ShowLevelComplate()
    {
        levelCompleteUI.SetActive(true);
        Time.timeScale = 0f;
    }

    

    public void ShowEnding()
    {
        levelCompleteUI.SetActive(false);
        //gamePlayUI.SetActive(false);
        ending.SetActive(true);
        Time.timeScale = 0f;
    }
}
