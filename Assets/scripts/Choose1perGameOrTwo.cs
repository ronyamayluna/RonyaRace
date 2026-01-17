using UnityEngine;
using System.Collections;

public class Choose1perGameOrTwo : MonoBehaviour
{

    [SerializeField] private float displayImageDuration = 5f;
    [SerializeField] float fadeDuration = 1f;
    public CanvasGroup exitBackgroundImageCanvasGroup;

//    void Start()
//    {
//        StartCoroutine(ShowCanvasForSeconds());
//    }

//    private IEnumerator ShowCanvasForSeconds()
//    {
//        // Показываем канвас
//        exitBackgroundImageCanvasGroup.alpha = 1f;
//        exitBackgroundImageCanvasGroup.interactable = true;
//        exitBackgroundImageCanvasGroup.blocksRaycasts = true;

//        // Ждём заданное время
//        yield return new WaitForSeconds(displayImageDuration);

//        // Скрываем канвас
//        exitBackgroundImageCanvasGroup.alpha = 0f;
//        exitBackgroundImageCanvasGroup.interactable = false;
//        exitBackgroundImageCanvasGroup.blocksRaycasts = false;
//    }
}
