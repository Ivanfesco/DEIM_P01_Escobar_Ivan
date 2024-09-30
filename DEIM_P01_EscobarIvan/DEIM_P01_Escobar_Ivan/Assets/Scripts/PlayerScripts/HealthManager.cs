using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HealthManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int health = 3;

    private void Update()
    {
        
        if(health <1)
        {

            Destroy(gameObject);

        }

    }

}
