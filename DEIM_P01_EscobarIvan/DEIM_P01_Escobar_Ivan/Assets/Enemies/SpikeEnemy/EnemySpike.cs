using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class EnemySpike : MonoBehaviour
{
    [SerializeField]private int damage = 1;
    private HealthManager playerhealthmanvar;
    private Vector2 impulsevec;
    private float raycastdistance = 1;
    private bool FacingLeft;
    private bool LeftDown;
    private bool RightDown;
    private float maxvel = 1;
    [SerializeField] SpriteRenderer spriterend;
    [SerializeField] Rigidbody2D rbref;
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
    private void Update()
    {
        if (FacingLeft)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(-0.5f, -0.5f, 0), Vector3.down, raycastdistance);
            Debug.DrawRay(transform.position + new Vector3(-0.5f, -0.5f, 0), Vector3.down, Color.red, 1);
            if (!hit)
            {
                FacingLeft = false;
                rbref.velocity = new Vector2(0, rbref.velocity.y);
            }

        }
        else
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(0.5f, -0.5f, 0), Vector3.down, raycastdistance);
            Debug.DrawRay(transform.position + new Vector3(0.5f, -0.5f, 0), Vector3.down, Color.green, 1);
            if (!hit)
            {
                FacingLeft = true;
                rbref.velocity = new Vector2(0, rbref.velocity.y);
            }
        }



        spriterend.flipX = !FacingLeft;

        if (FacingLeft)
        {
            rbref.AddForce(Vector2.left * 500 * Time.deltaTime);
        }
        else
        {
            rbref.AddForce(Vector2.right * 500 * Time.deltaTime);
        }

        if (Mathf.Abs(rbref.velocity.x) > maxvel)
        {
            rbref.velocity = new Vector2(Mathf.Clamp(rbref.velocity.x, -maxvel, maxvel), rbref.velocity.y);
        }

 

    }
}
