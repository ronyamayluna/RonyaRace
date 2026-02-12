using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] bool thirdPersonCamera = true;
    [SerializeField] Camera thirdPersonCam;
    [SerializeField] Camera firstPersonCam;
    [SerializeField] GameObject player;
    [SerializeField] Vector3 offset = new Vector3(0, 5, -10);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        thirdPersonCamera = true;
        thirdPersonCam.enabled = true;
        firstPersonCam.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightAlt) & thirdPersonCamera == true)
        {
            thirdPersonCamera = false;
            thirdPersonCam.enabled = false;
            firstPersonCam.enabled = true;

        }
        else if (Input.GetKeyDown(KeyCode.RightAlt) & thirdPersonCamera == false)
        {
            thirdPersonCamera = true;
            thirdPersonCam.enabled = true;
            firstPersonCam.enabled = false;
        }
    }
}
