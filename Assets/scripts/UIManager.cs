using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject canvasstart;
    [SerializeField] GameObject canvasSettings;
    [SerializeField] GameObject canvasStop;

    [SerializeField] GameObject canvasOne;
    [SerializeField] GameObject canvasTwo;
    [SerializeField] GameObject canvasThree;
    [SerializeField] float delaySecondsOne = 5f;
    [SerializeField] float delaySecondsTwo = 5f;
    [SerializeField] float delaySecondsThree = 5f;
    [SerializeField] GameObject canvasStartText;


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
        StartCoroutine(ShowCanvasOneWithDelay(canvasOne, delaySecondsOne));
        StartCoroutine(ShowCanvasTwoWithDelay(canvasTwo, delaySecondsTwo));
        StartCoroutine(ShowCanvasThreeWithDelay(canvasThree, delaySecondsThree));
        StartCoroutine(CloseCanvasThreeWithDelay(canvasThree, 5f));
        StartCoroutine(CloseCanvasStartWithDelay(canvasStartText, 6f));
        
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

    IEnumerator ShowCanvasOneWithDelay(GameObject canvas, float delaySeconds)
    {
        yield return new WaitForSeconds(delaySecondsOne);
        canvasOne.SetActive(true);
    }
    IEnumerator ShowCanvasTwoWithDelay(GameObject canvas, float delaySeconds)
    {
        yield return new WaitForSeconds(delaySecondsTwo);
        canvasTwo.SetActive(true);
        canvasOne.SetActive(false);
    }
    IEnumerator ShowCanvasThreeWithDelay(GameObject canvas, float delaySeconds)
    {
        yield return new WaitForSeconds(delaySecondsThree);
        canvasThree.SetActive(true);
        canvasTwo.SetActive(false);
    }
    IEnumerator CloseCanvasThreeWithDelay(GameObject canvas, float delaySeconds)
    {
        yield return new WaitForSeconds(5f);
        canvasThree.SetActive(false);
        canvasStartText.SetActive(true);
    }
    IEnumerator CloseCanvasStartWithDelay(GameObject canvas, float delaySeconds)
    {
        yield return new WaitForSeconds(6f);
        canvasStartText.SetActive(false);
    }
}

