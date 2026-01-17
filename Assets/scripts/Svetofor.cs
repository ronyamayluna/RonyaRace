using UnityEngine;
using System.Collections;

public class Svetofor : MonoBehaviour
{
    [SerializeField] Color newColor = Color.yellow;
    [SerializeField] float delaySeconds = 3f; // Время задержки в секундах
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
