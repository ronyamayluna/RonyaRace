using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject canvasstart;
    [SerializeField] GameObject canvasSettings;
    [SerializeField] GameObject canvasStop;

    void Start()
    {
        Time.timeScale = 0f;
        canvasstart.SetActive(true);
        canvasStop.SetActive(false);
    }

    public void StartGame()
    {
        Debug.Log("StartGame");
        canvasstart.SetActive(false);
        Debug.Log("ttt");
        Time.timeScale = 1f;
        
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StopGame();
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void StopGame()
    {
        canvasStop.SetActive(true);
        Time.timeScale = 0f;
        
    }

    public void CloseStopUI()
    {
        canvasStop.SetActive(false);
        Time.timeScale = 1f;
    }
    public void OpenSettingsUI()
    {
        canvasSettings.SetActive(true);
    }
    public void CloseSettingsUI()
    {
        canvasSettings.SetActive(false);
    }
}

