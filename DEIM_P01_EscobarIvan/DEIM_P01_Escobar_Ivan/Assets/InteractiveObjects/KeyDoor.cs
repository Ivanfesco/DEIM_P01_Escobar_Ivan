using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class KeyDoor : MonoBehaviour
{
    [SerializeField] private string SceneToLoad;
    private InventoryScript inventoryvar;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            inventoryvar = collision.gameObject.GetComponent<InventoryScript>();

        }
    }



}
