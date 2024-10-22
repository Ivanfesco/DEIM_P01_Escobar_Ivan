using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class HelmetEnemyScript : MonoBehaviour
{
    private float raycastdistance = 1;
    private bool FacingLeft;
    private bool LeftDown;
    private bool RightDown;
    private float maxvel = 2;
    private float speedmult = 1;
    [SerializeField] SpriteRenderer spriterend;
    [SerializeField] Rigidbody2D rbref;
    [SerializeField] HelmetScript helmet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (FacingLeft)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(-0.5f, -0.5f, 0), Vector3.down, raycastdistance);
            Debug.DrawRay(transform.position + new Vector3(-0.5f, -0.5f, 0), Vector3.down, Color.red, 1);
            if(!hit)
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
            rbref.AddForce(Vector2.left * 500 * Time.deltaTime * speedmult);
        }
        else
        {
            rbref.AddForce(Vector2.right * 500 * Time.deltaTime * speedmult);
        }
       
        if(Mathf.Abs(rbref.velocity.x) > maxvel)
        {
            rbref.velocity = new Vector2(Mathf.Clamp(rbref.velocity.x, -maxvel, maxvel), rbref.velocity.y);
        }

        if(!helmet.hasHelmet)
        {
            maxvel = 5;
            speedmult = 3;
        }


    }
}
