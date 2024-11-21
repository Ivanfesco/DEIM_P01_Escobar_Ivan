using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarbellScript : MonoBehaviour
{



    public void addBarbell()
    {

        InventoryScript.instance.extraDamage = InventoryScript.instance.extraDamage + 1;

    }
}
