using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class DeathManager : MonoBehaviour
{
    [SerializeField] public int health = 1;
    [SerializeField] public GameObject GameObjectToSpawn;
    [SerializeField] public int moneyworth = 1;
    [SerializeField] public bool stompable = true;
    [SerializeField] PlayerController pc;
    [SerializeField] bool ishelmet;
    [SerializeField] ParticleSystem particlestospawn;
    private void Start()
    {
        pc = FindAnyObjectByType<PlayerController>();
    }
    public void damage()
    {

        health = health - pc.damage ;

    }

    private void Update()
    {
        if (health < 1)
        {
            if (ishelmet)
            {

            }
            else
            {
                while (moneyworth > 0)
                {

                    Instantiate(GameObjectToSpawn, new Vector2(transform.position.x, transform.position.y), transform.rotation * Quaternion.Euler(new Vector3(0, 0, Random.Range(-45, 45))));
                    moneyworth--;


                }
                Instantiate(particlestospawn, transform.position, transform.rotation);

                AudioManager.playEnemySound("damage");
                Destroy(gameObject);
            }
        }
    }

}

