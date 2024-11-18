using System.Collections;
using System.Collections.Generic;
using TMPro;
//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class InventoryScript : MonoBehaviour
{

    [SerializeField] public TextMeshProUGUI moneytext;
    [SerializeField] private GameObject BulletCounter;
    [SerializeField] private Sprite[] bulletcounterarray;
    public int money = 0;

    public int bulletAmount;
    public int maxBulletAmount = 10;
    private UnityEngine.SceneManagement.Scene scene;

    private void Start()
    {
        scene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
    }
    private void Update()
    {

        if (scene.name.StartsWith("Forest"))
        {
            BulletCounter.gameObject.GetComponent<Image>().color = new Color32(45,176,130,255);
        }
        else if (scene.name.StartsWith("Tundra"))
        {
            BulletCounter.gameObject.GetComponent<Image>().color = new Color32(44, 196, 246, 255);
        }
        else if (scene.name.StartsWith("Desert"))
        {
            BulletCounter.gameObject.GetComponent<Image>().color = new Color32(238, 161, 96, 255);
        }

        moneytext.SetText(money.ToString());

        if (bulletAmount <= 13)
        {
                BulletCounter.GetComponent<Image>().sprite = bulletcounterarray[bulletAmount];
        }
        else
        {
            BulletCounter.GetComponent<Image>().sprite = bulletcounterarray[14];
        }


    }
}
