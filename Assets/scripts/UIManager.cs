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

    [SerializeField] GameObject winCanvas;
    [SerializeField] TMPro.TextMeshProUGUI winText;

    [SerializeField] GameObject wrongStartCanvasPlayerOne;
    [SerializeField] GameObject wrongStartCanvasPlayerTwo;

    [SerializeField] GameObject wrongOrderCanvasPlayerOne;
    [SerializeField] GameObject wrongOrderCanvasPlayerTwo;

    [SerializeField] GameObject winCanvasPlayerOne;
    [SerializeField] GameObject winCanvasPlayerTwo;

    [SerializeField] GameObject QuitCanvas;

    public static bool RaceStarted { get; private set; } = false;


    void Start()
    {
        Time.timeScale = 0f;
        canvasstart.SetActive(true);
        canvasStop.SetActive(false);
    }

    public void StartGame()
    {

        canvasstart.SetActive(false);
        Time.timeScale = 1f;

        RaceStarted = false;

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
        QuitCanvas.SetActive(true);
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

        RaceStarted = true;
    }

    private void OnEnable()
    {
        CheckpointManager.OnCheckpointResult += HandleCheckpointResult;
    }

    private void OnDisable()
    {
        CheckpointManager.OnCheckpointResult -= HandleCheckpointResult;
    }

    private void ShowWinScreen(int player)
    {
        Time.timeScale = 0f;
        if (player == 1)
        {
            winCanvasPlayerOne.SetActive(true);
            winCanvasPlayerTwo.SetActive(false);
        }
        else if (player == 2)
        {
            winCanvasPlayerTwo.SetActive(true);
            winCanvasPlayerOne.SetActive(false);
        }
        // winText.text = $"{player} WINS!";
    }

    private void ShowWrongStartScreen(int player)
    {
        if (player == 1)
        {
            wrongStartCanvasPlayerOne.SetActive(true);
        }
        else
        {
            wrongStartCanvasPlayerTwo.SetActive(true);
        }
    }

    private void ShowWrongOrderScreen(int player)
    {
        if (player == 1)
        {
            wrongOrderCanvasPlayerOne.SetActive(true);
        }
        else
        {
            wrongOrderCanvasPlayerTwo.SetActive(true);
        }
    }

    private void HideWrongScreen(int player)
    {
        if (player == 1)
        {
            wrongStartCanvasPlayerOne.SetActive(false);
            wrongOrderCanvasPlayerOne.SetActive(false);
        }
        else
        {
            wrongStartCanvasPlayerTwo.SetActive(false);
            wrongOrderCanvasPlayerTwo.SetActive(false);
        }
    }

    private void HandleCheckpointResult(int player, Status status)
    {
        if (status == Status.WIN)
        {
            ShowWinScreen(player);
        }
        else if (status == Status.WRONG_START)
        {
            ShowWrongStartScreen(player);
        }
        else if (status == Status.WRONG_ORDER)
        {
            ShowWrongOrderScreen(player);
        }
        else if (status == Status.CORRECT_ORDER)
        {
            HideWrongScreen(player);
        }
    }

}

