using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SugarScript : MonoBehaviour
{

    public void addSugar()
    {

        InventoryScript.instance.extraSpeed = InventoryScript.instance.extraSpeed + 1;

    }
}
