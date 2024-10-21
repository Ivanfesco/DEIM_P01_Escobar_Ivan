using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class HelmetScript : MonoBehaviour
{
    public bool hasHelmet = true;


    [SerializeField] private Rigidbody2D rbvar;
    [SerializeField] private ParentConstraint parentcont;
    [SerializeField] private BoxCollider2D boxcol;
    [SerializeField] private DeathManager DeathManager;
    private float destroy_timer;
    private float timer_start;
    private void Start()
    {
        DeathManager.stompable = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.name.StartsWith("BulletPrefab"))
        {
            if (hasHelmet)
            {
                boxcol.enabled = false;
                parentcont.constraintActive = false;
                Destroy(collision.gameObject);
                transform.rotation = transform.rotation * Quaternion.Euler(new Vector3(0, 0, Random.Range(-45, 45)));
                rbvar.gravityScale = 1;
                rbvar.AddRelativeForce(new Vector2(Random.Range(1, 4), Random.Range(3, 7)), ForceMode2D.Impulse);
                hasHelmet = false;
                timer_start = Time.time;
                DeathManager.stompable=true;
            }
        }

    }
    private void Update()
    {
        if (!hasHelmet)
        {
            if(destroy_timer < 3)
            {
                destroy_timer = Time.time - timer_start; 
            }
            if(destroy_timer > 3)
            {
                Destroy(gameObject);
            }
        }
    }
}
