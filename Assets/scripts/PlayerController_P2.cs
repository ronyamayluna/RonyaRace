using UnityEngine;

public class PlayerController_P2 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private float speed = 20f;
    [SerializeField] private float turnSpeed = 50f;
    float horisontalinput;
    float verticalinput;
    float forwardinput;
    float boostTimer;
    float timerDuration = 3f;
    [SerializeField] private float forwardspeed = 45f;
    bool isBoosting = false;

    // Update is called once per frame
    void Update()
    {
        horisontalinput = Input.GetAxis("Horizontal_P2");
        verticalinput = Input.GetAxis("Vertical_P2");
        forwardinput = Input.GetAxis("Fire3_P2");
        if (Input.GetKeyDown(KeyCode.RightShift) & !isBoosting)
        {
            isBoosting = true;
            boostTimer = timerDuration;
            //timerDuration -= Time.deltaTime;
            //while (boostTimer > 0)
            //{
            //    isBoosting = true;
            //}
        }

        if (isBoosting == true)
        {
            boostTimer -= Time.deltaTime;
            if (boostTimer <= 0f)
            {
                isBoosting = false;
            }
        }

        float currentSpeed = isBoosting ? forwardspeed : speed;

        //двигаем машинку вперед
        transform.Translate(Vector3.back * Time.deltaTime * currentSpeed * verticalinput);
        //transform.Translate(Vector3.left * Time.deltaTime * turnSpeed * horisontalinput);
        transform.Rotate(Vector3.up, horisontalinput * turnSpeed * Time.deltaTime);
        //if (isBoosting == true) ;
        //{
        //    transform.Translate(Vector3.back * Time.deltaTime * forwardspeed * forwardinput);
        //}

    }
}
