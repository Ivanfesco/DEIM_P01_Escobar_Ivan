using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class DeathManager : MonoBehaviour
{
    [SerializeField] public int health = 1;
    [SerializeField] public GameObject GameObjectToSpawn;
    [SerializeField] public int moneyworth = 1;


    public void damage()
    {

        health--;
        if (health < 1)
        {
            while (moneyworth > 0)
            {
                
                Instantiate(GameObjectToSpawn, new Vector2(transform.position.x, transform.position.y), transform.rotation * Quaternion.Euler(new Vector3(0, 0, Random.Range(-45, 45))));
                moneyworth--;


            }
            Destroy(gameObject);
        }
    }

}

