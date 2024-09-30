using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Key : MonoBehaviour
{
    // Start is called before the first frame update
    private InventoryScript inventoryvar;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            inventoryvar = collision.gameObject.GetComponent<InventoryScript>();
            inventoryvar.holdingkey = true;
            Destroy(gameObject);
        }
    }
}
