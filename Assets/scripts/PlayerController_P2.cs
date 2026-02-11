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
    [SerializeField] AudioClip _carSound;
    [SerializeField] AudioSource _carSoundSource;


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

        transform.Translate(Vector3.back * Time.deltaTime * currentSpeed * verticalinput);

        transform.Rotate(Vector3.up, horisontalinput * turnSpeed * Time.deltaTime);

        PlayCarSound();
    }

    void PlayCarSound()
    {
        // Если есть движение
        if (Mathf.Abs(verticalinput) > 0.1f || Mathf.Abs(horisontalinput) > 0.1f)
        {
            if (!_carSoundSource.isPlaying)
            {
                _carSoundSource.clip = _carSound;
                _carSoundSource.loop = true;
                _carSoundSource.Play();
            }

            // Немного меняем тональность в зависимости от скорости
            _carSoundSource.pitch = 1f + Mathf.Abs(verticalinput) * 0.5f;
        }
        else
        {
            if (_carSoundSource.isPlaying)
            {
                _carSoundSource.Stop();
            }
        }
    }
}