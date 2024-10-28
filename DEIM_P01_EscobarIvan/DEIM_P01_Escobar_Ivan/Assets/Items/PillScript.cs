using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillScript : MonoBehaviour
{
    // Start is called before the first frame update

    private HealthManager hm;

    private void Start()
    {
        hm = FindAnyObjectByType<HealthManager>();
    }

    public void addPill()
    {

        hm.maxHealth = hm.maxHealth + 1;

    }
}
