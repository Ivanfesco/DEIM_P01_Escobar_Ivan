using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTP1 : MonoBehaviour
{

    [SerializeField] GameObject otherTP;
    [SerializeField] int leftOrRightTP;


    private void Start()
    {

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.StartsWith("Player"))
        {

            collision.transform.position = otherTP.transform.position + new Vector3(leftOrRightTP, 0, 0);
            
        }

    }

}
