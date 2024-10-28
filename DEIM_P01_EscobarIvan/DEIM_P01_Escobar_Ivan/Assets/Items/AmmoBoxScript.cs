using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AmmoBoxScript : MonoBehaviour
{
    [SerializeField] InventoryScript invscript;
    // Start is called before the first frame update

    private void Start()
    {
        invscript = FindAnyObjectByType<InventoryScript>();
    }

    public void addAmmoBox()
    {
       
       invscript.maxBulletAmount= invscript.maxBulletAmount+1;

    }
}