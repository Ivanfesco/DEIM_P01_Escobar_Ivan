using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SugarScript : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerController pc;

    private void Start()
    {
        pc = FindAnyObjectByType<PlayerController>();
    }
    public void addSugar()
    {

        pc.speed = pc.speed + 1;

    }
}
