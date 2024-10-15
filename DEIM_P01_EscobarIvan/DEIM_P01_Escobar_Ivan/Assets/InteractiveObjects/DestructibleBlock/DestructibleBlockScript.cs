using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleBlockScript : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rbvar;


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.name.StartsWith("BulletPrefab"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

    }
   


    
}
