using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private GameObject player;
    Vector3 target;
    float screenshakeduration;
    float shakeendtime;
    float amplitude;
    bool shaking;
    public static CameraScript instance;
    // Start is called before the first frame update
    private void Start()
    {

        findplayer();
        gameObject.transform.position = new Vector3(0, player.transform.position.y, -2);

    }

    public void findplayer()
    {
        player = FindAnyObjectByType<PlayerController>().gameObject;


    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        if(FindAnyObjectByType<Camera>() != null && FindAnyObjectByType<Camera>().gameObject != gameObject)
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            print("destroyattempt");
            Destroy(gameObject);
        }

        target = new Vector3(0, player.transform.position.y + player.GetComponent<Rigidbody2D>().velocity.y / 10, -2);
        if (Mathf.Abs(player.transform.position.x) < 50 )
        {
            //     gameObject.transform.position = new Vector3(0, player.transform.position.y + player.GetComponent<Rigidbody2D>().velocity.y / 10, -2);
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position,target , Mathf.Abs(gameObject.transform.position.y - target.y) / 2 );
        }
        else
        {
            gameObject.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -2);
        }

        if (shaking)
        {
            if (Time.time < shakeendtime)
            {
                //do the shake

                gameObject.transform.position = gameObject.transform.position + new Vector3(Random.Range(-amplitude, amplitude), Random.Range(-amplitude, amplitude), 0);

            }
            else
            {
                shaking = false;
            }
        }



    }

    public static void ScreenShake(float duration, float Amplitude)
    {
        if (instance != null)
        {
            instance.screenshakeduration = duration;
            instance.shakeendtime = Time.time + duration;
            instance.amplitude = Amplitude;
            instance.shaking = true;
        }

    }

}
