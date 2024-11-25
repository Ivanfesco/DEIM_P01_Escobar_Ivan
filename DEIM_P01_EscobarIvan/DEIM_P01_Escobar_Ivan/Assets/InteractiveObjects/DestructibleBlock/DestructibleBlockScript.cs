using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleBlockScript : MonoBehaviour
{
    [SerializeField] ParticleSystem particlestospawn;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.name.StartsWith("BulletPrefab"))
        {
            Destroy(collision.gameObject);
            Instantiate(particlestospawn, transform.position, transform.rotation);
            AudioManager.playIntObjSound("block");
            Destroy(gameObject);
           
            

        }

    }
   


    
}
