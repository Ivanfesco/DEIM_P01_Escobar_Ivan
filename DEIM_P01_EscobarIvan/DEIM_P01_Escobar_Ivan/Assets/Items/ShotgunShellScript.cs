using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunShellScript : MonoBehaviour
{

    public void addShotgunShell()
    {

        InventoryScript.instance.extraBullets = InventoryScript.instance.extraBullets + 1;

    }
}
