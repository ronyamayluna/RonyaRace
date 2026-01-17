using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject panelSettings;
    private void Start()
    {
        panelSettings.SetActive(false);
    }
    public void Play()
    {
        SceneManager.LoadScene("GameScene");
    }
}
