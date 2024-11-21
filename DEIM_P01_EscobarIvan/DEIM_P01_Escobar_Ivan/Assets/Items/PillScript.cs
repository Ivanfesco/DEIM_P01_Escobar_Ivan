using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillScript : MonoBehaviour
{

    public void addPill()
    {

        HealthManager.instance.maxHealth = HealthManager.instance.maxHealth + 1;

    }
}
