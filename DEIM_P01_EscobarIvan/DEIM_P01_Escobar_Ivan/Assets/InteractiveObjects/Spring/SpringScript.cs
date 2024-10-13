using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringScript : MonoBehaviour
{


    [SerializeField] Animator animator;
    [SerializeField] BoxCollider2D boxCollider;
    bool bounceable = true;
    float timer;
    float timeElapsed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (bounceable)
            {   
                bounceable = false;
                animator.Play("SpringBounce", -1, 0f);
                collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(collision.gameObject.GetComponent<Rigidbody2D>().velocity.x, 0f);
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 10) * Time.deltaTime * 50, ForceMode2D.Impulse);
                timer = 0;
                timeElapsed = Time.time;

            }


        }
    }

    private void Update()
    {
        if(timer <= 1)
        {
            timer = Time.time - timeElapsed;

        }
        if (timer >= 1)
        {
            bounceable = true;
        }
    }
} 
