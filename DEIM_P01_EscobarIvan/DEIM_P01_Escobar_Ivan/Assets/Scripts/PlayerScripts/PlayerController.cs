using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    public Sprite[] spriteArray;
    [SerializeField] private SpriteRenderer spriterender;
    [SerializeField] private Rigidbody2D rigidbod;
    [SerializeField] private float speed = 20;
    [SerializeField] private float jumpspeed = 300;
    [SerializeField] private Collider2D groundcol;
    [SerializeField] private TilemapCollider2D tilecol;
    private bool grounded = false;
    private float yvelocity = 0;
    private float xvelocity = 0;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        yvelocity = rigidbod.velocity.y;
        xvelocity = rigidbod.velocity.x;
        print(xvelocity);
        if (Input.GetKey(KeyCode.D))
        {
            rigidbod.AddForce(Vector2.right * speed);
            spriterender.flipX = true;
        }
        else
        {
            rigidbod.velocity = new Vector2(0, yvelocity);

        }

        if (Input.GetKey(KeyCode.A))
        {
            rigidbod.AddForce(Vector2.left * speed);
            spriterender.flipX = false;
        }
        else
        {
            rigidbod.velocity = new Vector2(0, yvelocity);

        }
        yvelocity = rigidbod.velocity.y;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded == true)
            {
                rigidbod.AddForce(Vector2.up * jumpspeed);
            }
        }

        if (groundcol.IsTouching(tilecol))
        {
            grounded = true;
            spriterender.sprite = spriteArray[0];
        }
        else
        {
            grounded = false;
            spriterender.sprite = spriteArray[1];
        }
    }
}
