using System.Collections;
using UnityEngine;

public class SvetoforGreen : MonoBehaviour
{
    [SerializeField] Color newColor = Color.green;
    [SerializeField] float delaySeconds = 5f; // Время задержки в секундах
    Renderer objectRenderer;

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        StartCoroutine(ChangeColorWithDelay());
    }

    IEnumerator ChangeColorWithDelay()
    {
        yield return new WaitForSeconds(delaySeconds); // Задержка
        objectRenderer.material.color = newColor;
    }
}

