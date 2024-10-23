using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BlockEnemyScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject playerRef;
    private Transform starttrf;

    public enum EnemyState { Idle, Attack};
    public EnemyState State;

    // Update is called once per frame

    private void Start()
    {
        starttrf = gameObject.transform;
        State=EnemyState.Idle;
    }
    void Update()
    {
        if(Mathf.Abs(Mathf.Abs(playerRef.transform.position.x) - Mathf.Abs(gameObject.transform.position.x)) < 2 )
        {
            State = EnemyState.Attack;
        }

        switch (State)
        {

            case EnemyState.Idle:

                
                

                break;


            case EnemyState.Attack:

                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -4));

                BoxCollider2D boxcol = gameObject.GetComponent<BoxCollider2D>();
                 void OnTriggerEnter2D(Collider2D collision)
                 {
                    State = EnemyState.Idle;
                 }

                break;
        }
    }
}
