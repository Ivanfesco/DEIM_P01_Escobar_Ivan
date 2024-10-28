using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyringeScript : MonoBehaviour
{
    private PlayerController pc;

    private void Start()
    {
        pc = FindAnyObjectByType<PlayerController>();
    }

    // Start is called before the first frame update
    public void addSyringe()
    {

        pc.maxvel = pc.maxvel + 1;

    }
}
