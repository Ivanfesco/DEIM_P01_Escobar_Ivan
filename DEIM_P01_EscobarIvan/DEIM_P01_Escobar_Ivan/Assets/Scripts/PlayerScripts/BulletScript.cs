using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class BulletScript : MonoBehaviour
{

    [SerializeField] private BoxCollider2D boxcol;
    [SerializeField] private Rigidbody2D rigidbodref;
    private int maxvel = 10;

    // Start is called before the first frame update
    void Start()
    {
        
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
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else if(collision.gameObject == gameObject)
        {
            print("bullet collision");
        }

        else
        {

            Destroy(gameObject);

        }


    }
}

