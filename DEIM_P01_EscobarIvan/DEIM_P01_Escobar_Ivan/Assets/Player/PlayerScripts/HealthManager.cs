using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class HealthManager : MonoBehaviour
{
    [SerializeField] private Sprite[] heartarray;
    [SerializeField] private GameObject hearticon1;
    [SerializeField] private GameObject hearticon2;
    [SerializeField] private GameObject hearticon3;
    [SerializeField] private GameObject gameovercanvas;
    [SerializeField] float timer = 0;
    float timeElapsed = 0;
    [SerializeField] bool damageable = true;
    float immunitytime = 1;
    public int health = 3;
    public int maxHealth = 3;
    bool flippingBool;
    float flippingTimer;
    private Image[] images;
    public static HealthManager instance;
    private PlayerController pc;

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
    }

    void Start()
    {
        checkForIcons();

        gameovercanvas = pc.transform.Find("gameovercanvas").gameObject;

        gameovercanvas.SetActive(false);


    }


    public void checkForIcons()
    {
        pc = FindAnyObjectByType<PlayerController>();

        gameovercanvas = pc.transform.Find("gameovercanvas").gameObject;

        images = FindObjectsOfType<Image>();

        foreach (var item in images)
        {
            switch (item.gameObject.name)
            {
                case "hearticon1":
                    hearticon1 = item.gameObject;
                    break;
                case "hearticon2":
                    hearticon2 = item.gameObject;
                    break;
                case "hearticon3":
                    hearticon3 = item.gameObject;
                    break;
                default:
                    break;

            }
        }

        


    }


    private void Update()
    {
        //reset health and max health
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "MainMenu")
        {
            health = 3;
            maxHealth = 3;
        }

        if (instance.health > instance.maxHealth)
        {
            instance.health = instance.maxHealth;
        }


        

        switch (instance.health)
        {

            case 3:
                instance.hearticon1.GetComponent<Image>().sprite = instance.heartarray[1];
                instance.hearticon2.GetComponent<Image>().sprite = instance.heartarray[1];
                instance.hearticon3.GetComponent<Image>().sprite = instance.heartarray[1];
                break;

            case 2:
                instance.hearticon1.GetComponent<Image>().sprite = instance.heartarray[1];
                instance.hearticon2.GetComponent<Image>().sprite = instance.heartarray[1];
                instance.hearticon3.GetComponent<Image>().sprite = instance.heartarray[0];
                break;

            case 1:
                instance.hearticon1.GetComponent<Image>().sprite = instance.heartarray[1];
                instance.hearticon2.GetComponent<Image>().sprite = instance.heartarray[0];
                instance.hearticon3.GetComponent<Image>().sprite = instance.heartarray[0];
                break;

            case < 1:
                instance.hearticon1.GetComponent<Image>().sprite = instance.heartarray[0];
                instance.hearticon2.GetComponent<Image>().sprite = instance.heartarray[0];
                instance.hearticon3.GetComponent<Image>().sprite = instance.heartarray[0];
                instance.gameovercanvas.SetActive(true);
                instance.pc.inputallowed = false;
                break;



        }

        if (instance.timer <= instance.immunitytime)
        {
            instance.timer = Time.time - instance.timeElapsed;

        }
        if (instance.timer >= instance.immunitytime)
        {
            instance.damageable = true;
        }

        if (!instance.damageable)
        {
            instance.pc.gameObject.GetComponent<Animator>().SetBool("IsDamaged", true);
            if (Time.time > instance.flippingTimer)
            {
                instance.flippingTimer = Time.time + 0.1f;
                instance.flippingBool = !instance.flippingBool;
            }

            if (instance.flippingBool)
            {
                instance.pc.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0, 50);

            }
            else
            {
                instance.pc.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 100);

            }

        }
        else
        {
            instance.pc.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
            instance.pc.gameObject.GetComponent<Animator>().SetBool("IsDamaged", false);

        }

    }

    public void PlayerDamage(int damage)

    {
        if (damageable)
        {
            CameraScript.ScreenShake(0.2f, 0.2f);
            AudioManager.playDamage();
            damageable = false;
            health = health - damage;
            timer = 0;
            timeElapsed = Time.time;
            flippingTimer = Time.time + 0.1f;
        }
    }
}
