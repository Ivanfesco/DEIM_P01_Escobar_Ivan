using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;



public class BulletScript : MonoBehaviour
{

    [SerializeField] private BoxCollider2D boxcol;
    [SerializeField] private Rigidbody2D rigidbodref;
    [SerializeField] private SpriteRenderer spriterenderer;
    private int maxvel = 10;
    private DeathManager deathman;
    private PlayerController pc;

    private void Start()
    {
        pc = FindAnyObjectByType<PlayerController>();

        if (Random.Range(0, 2) == 1)
        {
            spriterenderer.flipX = true;
        }
        rigidbodref.AddRelativeForce(Vector2.down*15, ForceMode2D.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        if(rigidbodref.velocity.y > maxvel)
        {
            rigidbodref.velocity = new Vector2(rigidbodref.velocity.x, rigidbodref.velocity.y - 0.001f);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {


        }
        else if (collision.CompareTag("Enemy"))
        {
            deathman = collision.gameObject.GetComponent<DeathManager>();
            deathman.damage();
            if (!pc.hasBulletPenetration)
            {
                Destroy(gameObject);
            }
        }

        else
        {

            Destroy(gameObject);

        }


    }
}

