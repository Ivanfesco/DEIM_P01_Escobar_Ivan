using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpike : MonoBehaviour
{
    [SerializeField]private int damage = 1;
    private HealthManager healthmanvar;
    private Vector2 impulsevec;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            impulsevec = collision.gameObject.transform.position - transform.position;
            healthmanvar = collision.gameObject.GetComponent<HealthManager>();
            healthmanvar.health = healthmanvar.health - damage;
            print(healthmanvar.health);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(impulsevec.x * 300, impulsevec.y * 200));

        }

    }
}
