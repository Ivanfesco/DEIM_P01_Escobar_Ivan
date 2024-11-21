using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class BlockEnemyScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject playerRef;
    Rigidbody2D rb;
    private Vector3 startpos;

    public enum EnemyState { Idle, Attack, Returning};
    public EnemyState State;
    bool attacking;
    private PlayerController pc;
    
    // Update is called once per frame

    private void Start()
    {
        pc = FindAnyObjectByType<PlayerController>();
        playerRef = pc.gameObject;
        rb = gameObject.GetComponent<Rigidbody2D>();
        startpos = gameObject.transform.position;
        State=EnemyState.Idle;
    }
    void Update()
    {


        switch (State)
        {

            case EnemyState.Idle:


                if (playerRef.transform.position.x < gameObject.transform.position.x + 2 && playerRef.transform.position.x > gameObject.transform.position.x - 2)
                {
                    if (playerRef.transform.position.y < gameObject.transform.position.y)
                    {
                        State = EnemyState.Attack;
                    }
                }
                rb.constraints = RigidbodyConstraints2D.FreezeAll;

                break;


            case EnemyState.Attack:
                gameObject.GetComponent<Animator>().SetBool("Attacking", true);
                rb.AddForce(new Vector2(0, -4));

                attacking = true;
                rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
                    break;

            case EnemyState.Returning:
                gameObject.GetComponent<Animator>().SetBool("Attacking", false);
                if (gameObject.transform.position.y < startpos.y)
                {
                    rb.AddForce(new Vector2(0, 0.1f));
                }
                else
                {
                    rb.velocity=Vector3.zero;
                    State = EnemyState.Idle;
                }
                


             break;

            

        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (attacking)
        {
            if (collision.collider.name.StartsWith("Player"))
            {
                HealthManager.instance.PlayerDamage(1);
            }
            print(collision.collider.name);
                State = EnemyState.Returning;
                attacking = false;

            
        }
        
    }
}
