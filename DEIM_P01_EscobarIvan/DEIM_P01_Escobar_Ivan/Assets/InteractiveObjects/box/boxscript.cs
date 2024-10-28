using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxscript : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rbvar;
    [SerializeField] private GameObject GameObjectToSpawn;
    [SerializeField] private BoxCollider2D boxcol;
    private DeathManager deathman;
    float previousVelocity = 0f;
    int frames = 0;
    int coinstospawn = 0;


    // Update is called once per frame
    void Update()
    {
        if (frames > 10)
        {
            previousVelocity = rbvar.velocity.y;
            frames = 0;
        }
        else
        {
            frames++;
        }


        if (Mathf.Abs(rbvar.velocity.y) < 0.01f && Mathf.Abs(previousVelocity) >= 4 && rbvar.velocity.y != previousVelocity)
        {


            spawncoinsondeath();

            Destroy(gameObject);



        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Enemy"))
        {
            deathman = collision.gameObject.GetComponent<DeathManager>();
            deathman.damage();
            spawncoinsondeath();
            Destroy(gameObject);
        }
        if (collision.name.StartsWith("BulletPrefab"))
        {
            Destroy(collision.gameObject);
            spawncoinsondeath();
            Destroy(gameObject);
        }

    }
   
    void spawncoinsondeath()
    {
        if (Random.Range(0, 4) >= 3)
        {
            coinstospawn = Random.Range(0, 3);
            while (coinstospawn >= 0)
            {
                Instantiate(GameObjectToSpawn, new Vector2(transform.position.x, transform.position.y), transform.rotation * Quaternion.Euler(new Vector3(0, 0, Random.Range(-45, 45))));
                coinstospawn--;
            }
        }


    }
}
