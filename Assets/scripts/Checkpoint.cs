using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public int checkpointNumber;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerOne"))
        {
            Status status = CheckpointManager.Instance.RegisterCheckpoint(1, checkpointNumber);
            HandleStatus(status, 1);
        }

        if (other.CompareTag("PlayerTwo"))
        {
            Status status = CheckpointManager.Instance.RegisterCheckpoint(2, checkpointNumber);
            HandleStatus(status, 2);
        }
    }

    private static void HandleStatus(Status status, int player)
    {
        switch (status)
        {
            case Status.WIN:
                Debug.Log($"Player {player} WIN!");
                break;

            case Status.CORRECT_ORDER:
                Debug.Log($"Player {player} correct checkpoint");
                break;

            case Status.WRONG_ORDER:
                Debug.Log($"Player {player} wrong order!");
                break;

            case Status.WRONG_START:
                Debug.Log($"Player {player} must start from 0!");
                break;
        }
    }

}
