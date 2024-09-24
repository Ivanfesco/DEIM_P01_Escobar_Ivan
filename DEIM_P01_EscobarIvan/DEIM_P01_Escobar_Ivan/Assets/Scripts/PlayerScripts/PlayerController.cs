using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rigidbod;
    [SerializeField] private float speed=1;
    [SerializeField] private float jumpspeed = 300;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.D)) 
        {
            rigidbod.AddForce(Vector2.right*speed);

        }
        
        if (Input.GetKey(KeyCode.A))
        {
            rigidbod.AddForce(Vector2.left * speed);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbod.AddForce(Vector2.up * jumpspeed);
        }
    }
}
