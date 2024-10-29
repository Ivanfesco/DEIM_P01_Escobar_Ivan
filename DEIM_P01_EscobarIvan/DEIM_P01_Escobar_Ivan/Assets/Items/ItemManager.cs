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
        addItemsAfterLoad();
    }
    public void addItem()
    {
        switch(gameobjectname)
        {
            case string gameobjectname when gameobjectname.StartsWith("Syringe"):

                gameObject.GetComponent<SyringeScript>().addSyringe();
                pc.items.Add("Syringe");
                break;

            case string gameobjectname when gameobjectname.StartsWith("Sugar"):
                gameObject.GetComponent<SugarScript>().addSugar();
                pc.items.Add("Sugar");
                break;


            case string gameobjectname when gameobjectname.StartsWith("Shotgun Shell"):
                gameObject.GetComponent<ShotgunShellScript>().addShotgunShell();
                pc.items.Add("Shotgun Shell");
                break;


            case string gameobjectname when gameobjectname.StartsWith("Pill"):
                gameObject.GetComponent<PillScript>().addPill();
                pc.items.Add("Pill");
                break;


            case string gameobjectname when gameobjectname.StartsWith("Green Tipped Bullet"):
                gameObject.GetComponent<GreenBullet>().addGreenBullet();
                pc.items.Add("Green Tipped Bullet");
                break;

            case string gameobjectname when gameobjectname.StartsWith("Barbell"):

                gameObject.GetComponent<BarbellScript>().addBarbell();
                pc.items.Add("Barbell");
                break;

            case string gameobjectname when gameobjectname.StartsWith("Bandage"):

                gameObject.GetComponent<BandageScript>().addBandage();
                pc.items.Add("Bandage");
                break;

            case string gameobjectname when gameobjectname.StartsWith("Ammo Box"):

                gameObject.GetComponent<AmmoBoxScript>().addAmmoBox();
                pc.items.Add("Ammo Box");
                break;


        }
    }

    public void addItemsAfterLoad()
    {
        for(int i = 0; i<ik.itemsKept.Count; i++)
        {
        string itemLoadToAdd = ik.itemsKept[i];
            switch (itemLoadToAdd)
            {
                case "Syringe":

                    ik.gameObject.GetComponent<SyringeScript>().addSyringe();
                    pc.items.Add("Syringe");
                    break;

                case "Sugar":
                    ik.gameObject.GetComponent<SugarScript>().addSugar();
                    pc.items.Add("Sugar");
                    break;


                case "Shotgun Shell":
                    ik.gameObject.GetComponent<ShotgunShellScript>().addShotgunShell();
                    pc.items.Add("Shotgun Shell");
                    break;


                case "Pill":
                    ik.gameObject.GetComponent<PillScript>().addPill();
                    pc.items.Add("Pill");
                    break;


                case "Green Tipped Bullet":
                    ik.gameObject.GetComponent<GreenBullet>().addGreenBullet();
                    pc.items.Add("Green Tipped Bullet");
                    break;

                case "Barbell":

                    ik.gameObject.GetComponent<BarbellScript>().addBarbell();
                    pc.items.Add("Barbell");
                    break;

                case "Bandage":

                    ik.gameObject.GetComponent<BandageScript>().addBandage();
                    pc.items.Add("Bandage");
                    break;

                case "Ammo Box":

                    ik.gameObject.GetComponent<AmmoBoxScript>().addAmmoBox();
                    pc.items.Add("Ammo Box");
                    break;


            }
            
        }
       
    }
}
