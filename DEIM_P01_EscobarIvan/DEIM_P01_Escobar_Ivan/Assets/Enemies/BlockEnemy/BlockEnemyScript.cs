using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class BlockEnemyScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject playerRef;
    private Transform starttrf;

    public enum EnemyState { Idle, Attack, Returning};
    public EnemyState State;

    // Update is called once per frame

    private void Start()
    {
        starttrf = gameObject.transform;
        State=EnemyState.Idle;
    }
    void Update()
    {


        switch (State)
        {

            case EnemyState.Idle:


                if (Mathf.Abs(Mathf.Abs(playerRef.transform.position.x) - Mathf.Abs(gameObject.transform.position.x)) < 2)
                {
                    State = EnemyState.Attack;
                }

                break;


            case EnemyState.Attack:

                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -4));

                BoxCollider2D boxcol = gameObject.GetComponent<BoxCollider2D>();

                RaycastHit2D hit = Physics2D.Raycast(gameObject.transform.position, Vector2.down * 0.65f, 0.5f);
                Debug.DrawRay(gameObject.transform.position, Vector2.down * 0.65f, Color.green, 1);
                if (!hit.collider.CompareTag("Enemy"))
                {

                    State = EnemyState.Returning;

                }
                    break;

                case EnemyState.Returning:
                if (gameObject.GetComponent<Rigidbody2D>().velocity.y < 2)
                {
                    if (gameObject.transform.position.y < starttrf.transform.position.y)
                    {
                        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 1));
                    }
                }


                break;
        }
    }
}
