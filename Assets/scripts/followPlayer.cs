using UnityEngine;

public class followPlayer : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Vector3 offset;
    [SerializeField] float smoothspeed = 0.125f;
    [SerializeField] float rotationspeed = 5f;


    void LateUpdaate()
    {
        Vector3 desiredPosition = player.TransformPoint(offset);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothspeed*Time.deltaTime);
        Quaternion desiredRotation = Quaternion.LookRotation(player.forward, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, rotationspeed * Time.deltaTime);
    }
}

