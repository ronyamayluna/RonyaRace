using UnityEngine;

public class RoundManager : MonoBehaviour
{
    private int currentRound = 0;
    private const int totalRounds = 3;
    private int collisionsInCurrentRound = 0;
    private const int collisionsNeededToCompleteRound = 3; // 1 касание для начала + 2 для завершения

    [SerializeField] private GameObject[] validCollisionObjects;
    [SerializeField] private bool debugMode = true;

    void Start()
    {
        Debug.Log("RoundManager инициализирован. Ожидание начала раунда...");
    }

    void Update()
    {
        
    }

    
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player") && IsValidCollisionObject(collision.gameObject))
        {
            collisionsInCurrentRound++;
            if (debugMode)
                Debug.Log($"Коллизия #{collisionsInCurrentRound} в раунде: '{collision.gameObject.name}'");
            
            if (collisionsInCurrentRound == 1)
            {
                // Начало нового раунда
                currentRound++;
                if (debugMode)
                    Debug.Log($"=== РАУНД {currentRound} НАЧАЛСЯ ===");
            }
            
            if (collisionsInCurrentRound == collisionsNeededToCompleteRound)
            {
                // Раунд завершен
                if (debugMode)
                    Debug.Log($"=== РАУНД {currentRound} ЗАВЕРШЕН ===");
                
                if (currentRound >= totalRounds)
                {
                    if (debugMode)
                        Debug.Log("🎉 ВСЕ 3 РАУНДА ЗАВЕРШЕНЫ! ИГРА ОКОНЧЕНА!");
                    // Здесь можно добавить логику завершения игры
                    Time.timeScale = 0f; // Пауза игры (опционально)
                }
                
                // Сброс счетчика для следующего раунда
                collisionsInCurrentRound = 0;
            }
        }
    }

    private bool IsValidCollisionObject(GameObject obj)
    {
        if (validCollisionObjects == null || validCollisionObjects.Length == 0)
        {
            if (debugMode)
                Debug.LogWarning("Массив validCollisionObjects пуст! Установите объекты в Inspector.");
            return false;
        }

        foreach (GameObject validObj in validCollisionObjects)
        {
            if (validObj == obj)
                return true;
        }

        return false;
    }

    // Методы для получения информации о текущем состоянии раундов
    public int GetCurrentRound() => currentRound;
    public int GetTotalRounds() => totalRounds;
    public int GetCollisionsInCurrentRound() => collisionsInCurrentRound;
    public bool IsGameComplete() => currentRound >= totalRounds;
}
