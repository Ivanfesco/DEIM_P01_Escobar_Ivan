using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AmmoBoxScript : MonoBehaviour
{
    [SerializeField] InventoryScript invscript;
    [SerializeField] GameObject player;

    // Start is called before the first frame update

    private void Start()
    {
        invscript = FindAnyObjectByType<InventoryScript>();
        player = FindAnyObjectByType<PlayerController>().gameObject;

    }

    public void addAmmoBox()
    {
       

       invscript.maxBulletAmount= invscript.maxBulletAmount+1;

    }
}
