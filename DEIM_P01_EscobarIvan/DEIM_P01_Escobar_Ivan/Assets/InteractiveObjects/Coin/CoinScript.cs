using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinScript : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    private InventoryScript inventoryvar;
    private bool coingiven;
    // Start is called before the first frame update
    void Start()
    {
        rb.AddRelativeForce(new Vector2(0, Random.Range(3,7)), ForceMode2D.Impulse);
        inventoryvar = FindAnyObjectByType<InventoryScript>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!coingiven)
            {
                coingiven = true;
                inventoryvar.money++;
                Destroy(gameObject);
            }

        }
    }
}
