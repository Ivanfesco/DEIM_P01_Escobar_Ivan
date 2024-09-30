using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpike : MonoBehaviour
{
    [SerializeField]private int damage = 1;
    private HealthManager healthmanvar;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            healthmanvar = collision.gameObject.GetComponent<HealthManager>();
            healthmanvar.health = healthmanvar.health - damage;
            print(healthmanvar.health);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up*300);
        }
    }
}
