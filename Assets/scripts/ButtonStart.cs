using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonStart : MonoBehaviour
{
    [SerializeField] GameObject canvasstart;

    void Start()
    {
        Time.timeScale = 0f;
        canvasstart.SetActive(true);
    }

    public void StartGame()
    {
        Debug.Log("StartGame() вызван");
        canvasstart.SetActive(false);
        Debug.Log("Канвас отключён");
        Time.timeScale = 1f;
        
        
    }
}

