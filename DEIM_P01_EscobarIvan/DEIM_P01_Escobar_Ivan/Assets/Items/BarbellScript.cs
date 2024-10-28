using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarbellScript : MonoBehaviour
{
    [SerializeField] PlayerController pc;
    // Start is called before the first frame update

    private void Start()
    {
        pc = FindAnyObjectByType<PlayerController>();
    }

    public void addBarbell()
    {

        pc.damage = pc.damage + 1;

    }
}
