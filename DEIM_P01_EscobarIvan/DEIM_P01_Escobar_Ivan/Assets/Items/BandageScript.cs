using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BandageScript : MonoBehaviour
{
    [SerializeField] HealthManager hm;
    private void Start()
    {
        hm = FindAnyObjectByType<HealthManager>();
    }
    // Start is called before the first frame update
    public void addBandage()
    {
        
        hm.health = hm.health + 1;

    }
}
