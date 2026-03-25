using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Status
{
    WIN,
    CORRECT_ORDER,
    WRONG_ORDER,
    WRONG_START
}

public class CheckpointManager : MonoBehaviour
{
    public static CheckpointManager Instance;
    private List<int> playerOneStack = new();
    private List<int> playerTwoStack = new();


    private readonly int[] correctOrder = { 0, 1, 2, 3, 4, 5, 6, 7, 0 };

    public static event Action<int, Status> OnCheckpointResult;

    private void Awake()
    {
        Instance = this;
    }

    public Status RegisterCheckpoint(int player, int checkpointNumber)
    {
        List<int> list = player == 1 ? playerOneStack : playerTwoStack;
        Debug.Log($"Player {player} reached checkpoint {checkpointNumber} with stack: {string.Join(", ", list)}");

        // Если первый чекпоинт не 0
        if (list.Count == 0 && checkpointNumber != 0)
        {
            OnCheckpointResult?.Invoke(player, Status.WRONG_START);
            return Status.WRONG_START;
        }

        int expectedIndex = list.Count;

        // Если идёт строго по порядку
        if (checkpointNumber == correctOrder[expectedIndex])
        {
            list.Add(checkpointNumber);

            if (list.Count == correctOrder.Length)
            {
                OnCheckpointResult?.Invoke(player, Status.WIN);
                return Status.WIN;
            }

            OnCheckpointResult?.Invoke(player, Status.CORRECT_ORDER);
            return Status.CORRECT_ORDER;
        }

        int correctIndex = Array.IndexOf(correctOrder, checkpointNumber);

        if (correctIndex >= 0 && correctIndex < list.Count)
        {

            list.RemoveRange(correctIndex, list.Count - correctIndex);

            list.Add(checkpointNumber);

            OnCheckpointResult?.Invoke(player, Status.CORRECT_ORDER);
            return Status.CORRECT_ORDER;
        }

        OnCheckpointResult?.Invoke(player, Status.WRONG_ORDER);
        return Status.WRONG_ORDER;
    }

}
