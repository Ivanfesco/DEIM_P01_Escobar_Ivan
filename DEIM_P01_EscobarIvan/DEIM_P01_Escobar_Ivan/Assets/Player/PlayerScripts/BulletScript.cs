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
    private void Start()
    {
        if (Random.Range(0, 2) == 1)
        {
            spriterenderer.flipX = true;
        }

    }
    // Update is called once per frame
    void Update()
    {
        rigidbodref.AddRelativeForce(Vector2.down, ForceMode2D.Impulse);
        rigidbodref.velocity = new Vector2(Mathf.Clamp(rigidbodref.velocity.x, -maxvel/4, maxvel/4), Mathf.Clamp(rigidbodref.velocity.y, -maxvel, maxvel));


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
            Destroy(gameObject);
        }

        else
        {

            Destroy(gameObject);

        }


    }
}

