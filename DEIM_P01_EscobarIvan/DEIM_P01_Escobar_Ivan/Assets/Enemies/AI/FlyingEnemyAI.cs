using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

public class FlyingEnemyAI : MonoBehaviour
{
    public enum EnemyState { Idle, Chase, Move, Attack, Dead };
    public EnemyState State;
    [SerializeField] private DeathManager deathman;
    [SerializeField] private Transform playerTrf;
    [SerializeField] private GameObject player;
    [SerializeField] private float followRange;
    [SerializeField] private LayerMask layermask;
    private AIPath aiAgent;
    private Vector2 impulsevec;
    [SerializeField] private int damage = 1;
    private HealthManager playerhealthmanvar;


    // Start is called before the first frame update

    private void Awake()
    {
        aiAgent = GetComponent<AIPath>();
    }

    void Start()
    {
        player = FindAnyObjectByType<PlayerController>().gameObject;
        playerTrf =player.gameObject.GetComponent<Transform>();
        State = EnemyState.Chase;
    }

    // Update is called once per frame
    void Update()
    {
        if (State != EnemyState.Dead)
        {

            if (deathman.health < 0)
            {
                GoDie();
            }
            else
            {
                switch (State)
                {

                    case EnemyState.Chase:
                        if (!InFollowRange())
                        {
                            GoIdle();
                        }
                        else if (InAttackRange())
                        {
                            GoAttack();
                        }
                        else
                        {
                            aiAgent.destination = playerTrf.position-new Vector3(0, 1.5f, 0);
                        }
                        break;


                    case EnemyState.Idle:
                        if(InFollowRange())
                        {
                            aiAgent.canMove = true;
                            State = EnemyState.Chase;
                        }
                        else
                        {
                            aiAgent.canMove = false;
                        }


                        break;

                    


                    case EnemyState.Move:
                        break;


                    case EnemyState.Attack:
                        aiAgent.canMove = false;
                        break; 


                    case EnemyState.Dead:
                        break;
                }

            }

        }

        void GoDie()
        {
            State = EnemyState.Dead;
        }

        void GoIdle()
        {
            State = EnemyState.Idle;
        }

        void GoAttack()
        {

        }
        
        bool InAttackRange()
        {
            return false;
        }

        bool InFollowRange()
        {
            bool res = false;

            RaycastHit2D hit = Physics2D.Raycast(transform.position, playerTrf.position - transform.position, followRange, layermask);
            Debug.DrawRay(transform.position, playerTrf.position - transform.position);
            if (hit.collider != null && hit.collider.name.StartsWith("Player"))
            {
                res = true;
            }


            return res;

        }
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            impulsevec = collision.gameObject.transform.position - transform.position;
            playerhealthmanvar = collision.gameObject.GetComponent<HealthManager>();
            HealthManager.instance.PlayerDamage(damage);
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(impulsevec.x * 300, impulsevec.y * 200));

        }

    }

}