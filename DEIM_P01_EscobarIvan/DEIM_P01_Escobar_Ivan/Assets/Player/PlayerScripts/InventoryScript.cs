using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class InventoryScript : MonoBehaviour
{
    [Tooltip("Referencia al icono de la llave")]
    [SerializeField] private GameObject keyuiIcon;
    [SerializeField] public TextMeshProUGUI moneytext;
    [SerializeField] private GameObject BulletCounter;
    [SerializeField] private Sprite[] bulletcounterarray;
    public int money = 0;
    public bool holdingkey = false;
    public int bulletAmount;
    public int maxBulletAmount = 10;

    private void Update()
    {

        if (holdingkey)
        {
            keyuiIcon.GetComponent<Image>().color = new Color(255, 255, 255, 1);
        }
        else
        {
            keyuiIcon.GetComponent<Image>().color = new Color(255, 255, 255, 0.3f);
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
