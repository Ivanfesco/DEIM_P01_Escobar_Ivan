using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItemScript : MonoBehaviour
{
    [SerializeField] private GameObject[] itemList;
    bool iscolliding = false;
    [SerializeField] GameObject spawneditem;
    private InventoryScript invscr;
    [SerializeField] private Sprite[] spritelist;
    // Start is called before the first frame update
    void Start()
    {
        invscr = FindAnyObjectByType<InventoryScript>();
        spawneditem = Instantiate(itemList[Random.Range(0, itemList.Length)], gameObject.transform.position + new Vector3(0, 1.5f, 0), Quaternion.identity, transform);
    }


    
    void Update()
    {
        if (iscolliding)
        {

            if (Input.GetKeyDown(KeyCode.E))
            {

                if (invscr.money >= spawneditem.GetComponent<ItemManager>().itemPrice)
                {
                    spawneditem.GetComponent<ItemManager>().addItem();
                    invscr.money = invscr.money - spawneditem.GetComponent<ItemManager>().itemPrice;
                    Destroy(spawneditem);
                    gameObject.GetComponent<SpriteRenderer>().sprite = spritelist[1];


                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name.StartsWith("Player"))
        {

            iscolliding = true;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.name.StartsWith("Player"))
        {
            iscolliding = false;
        }
    }
}
