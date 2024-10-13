using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeScript : MonoBehaviour
{
    
    [SerializeField] private int damage = 1;
    private HealthManager playerhealthmanvar;
    private Vector2 impulsevec;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            impulsevec = collision.gameObject.transform.position - transform.position;
            playerhealthmanvar = collision.gameObject.GetComponent<HealthManager>();
            playerhealthmanvar.PlayerDamage(damage);
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(impulsevec.x * 300, impulsevec.y * 200));

        }

    }
}
