using System.Collections;
using System.Collections.Generic;
using TMPro;
//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using System.Linq;
using System;


public class InventoryScript : MonoBehaviour
{

    [SerializeField] public TextMeshProUGUI moneytext;
    [SerializeField] private GameObject BulletCounter;
    [SerializeField] private Sprite[] bulletcounterarray;
    public int money = 0;
    public static InventoryScript instance;
    private Image[] images;
    private TextMeshProUGUI[] tmptexts;
    public int bulletAmount;
    public int maxBulletAmount = 10;
    [SerializeField] private UnityEngine.SceneManagement.Scene scene;

    public int extraDamage;
    public bool bulletPenetrationBool;
    public int extraBullets = 0;
    public int extraSpeed;
    public int extraMaxVel;

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


    private void Start()
    {
        
        CheckForIcons();
    }

    public void CheckForIcons()
    {
        scene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
        images = FindObjectsOfType<Image>();
        tmptexts = FindObjectsOfType<TextMeshProUGUI>();

        foreach (var item in images)
        {
            if (item.gameObject.name == "BulletCounter")
            {
                BulletCounter = item.gameObject;
            }
        }

        foreach (var item in tmptexts)
        {
            if(item.gameObject.name == "Coincount")
            {
                moneytext = item;
            }

        }


    }

    private void Update()
    {

        //reset all items
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "MainMenu")
        {
            money = 0;
            maxBulletAmount = 10;
            extraDamage = 0;
            extraBullets = 0;
            extraSpeed = 0;
            extraMaxVel = 0;
            extraSpeed = 0;
            bulletPenetrationBool = false;  
        }


        if (instance.scene.name.StartsWith("Forest"))
        {
            instance.BulletCounter.gameObject.GetComponent<Image>().color = new Color32(45,176,130,255);
        }
        else if (instance.scene.name.StartsWith("Tundra"))
        {
            instance.BulletCounter.gameObject.GetComponent<Image>().color = new Color32(44, 196, 246, 255);
        }
        else if (instance.scene.name.StartsWith("Desert"))
        {
            instance.BulletCounter.gameObject.GetComponent<Image>().color = new Color32(238, 161, 96, 255);
        }

        instance.moneytext.SetText(instance.money.ToString());

        if (instance.bulletAmount <= 13)
        {
                instance.BulletCounter.GetComponent<Image>().sprite = instance.bulletcounterarray[instance.bulletAmount];
        }
        else
        {
            instance.BulletCounter.GetComponent<Image>().sprite = instance.bulletcounterarray[14];
        }


    }
}
