using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] public int itemPrice = 1;
    public string gameobjectname;
    PlayerController pc;
    ItemKeeper ik;



    // Start is called before the first frame update
    private void Start()
    {
        gameobjectname = gameObject.name;
        pc = FindAnyObjectByType<PlayerController>();
        ik = FindAnyObjectByType<ItemKeeper>();

    }
    public void addItem()
    {
        switch(gameobjectname)
        {
            case string gameobjectname when gameobjectname.StartsWith("Syringe"):

                gameObject.GetComponent<SyringeScript>().addSyringe();
                
                break;

            case string gameobjectname when gameobjectname.StartsWith("Sugar"):
                gameObject.GetComponent<SugarScript>().addSugar();
                break;


            case string gameobjectname when gameobjectname.StartsWith("Shotgun Shell"):
                gameObject.GetComponent<ShotgunShellScript>().addShotgunShell();
                break;


            case string gameobjectname when gameobjectname.StartsWith("Pill"):
                gameObject.GetComponent<PillScript>().addPill();
                break;


            case string gameobjectname when gameobjectname.StartsWith("Green Tipped Bullet"):
                gameObject.GetComponent<GreenBullet>().addGreenBullet();
                break;

            case string gameobjectname when gameobjectname.StartsWith("Barbell"):

                gameObject.GetComponent<BarbellScript>().addBarbell();
                break;

            case string gameobjectname when gameobjectname.StartsWith("Bandage"):

                gameObject.GetComponent<BandageScript>().addBandage();
                break;

            case string gameobjectname when gameobjectname.StartsWith("Ammo Box"):

                gameObject.GetComponent<AmmoBoxScript>().addAmmoBox();
                break;


        }
    }

    
}
