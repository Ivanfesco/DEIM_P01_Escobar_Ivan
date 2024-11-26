using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ShopItemScript : MonoBehaviour
{
    [SerializeField] private GameObject[] itemList;
    bool iscolliding = false;
    [SerializeField] GameObject spawneditem;
    private InventoryScript invscr;
    [SerializeField] private Sprite[] spritelist;

    [SerializeField] private Canvas itemcanv;
    [SerializeField] private TextMeshProUGUI itemnametext;
    [SerializeField] private TextMeshProUGUI itemdesctext;
    [SerializeField] private TextMeshProUGUI itempricetext;

    

    // Start is called before the first frame update
    void Start()
    {
        itemcanv.gameObject.SetActive(false);
        spawneditem = Instantiate(itemList[Random.Range(0, itemList.Length)], gameObject.transform.position + new Vector3(0, 1.5f, 0), Quaternion.identity, transform);
        itemnametext.text = spawneditem.name.Substring(0, spawneditem.name.Length - 7);
        itemdesctext.text = InventoryScript.instance.itemdescdictionary[spawneditem.name.Substring(0, spawneditem.name.Length-7)];
        itempricetext.text = spawneditem.GetComponent<ItemManager>().itemPrice.ToString();
    }


    
    void Update()
    {
        if (iscolliding)
        {

            if (Input.GetKeyDown(KeyCode.E))
            {

                if (InventoryScript.instance.money >= spawneditem.GetComponent<ItemManager>().itemPrice)
                {
                    spawneditem.GetComponent<ItemManager>().addItem();
                    InventoryScript.instance.money = InventoryScript.instance.money - spawneditem.GetComponent<ItemManager>().itemPrice;
                    Destroy(spawneditem);
                    gameObject.GetComponent<SpriteRenderer>().sprite = spritelist[1];
                    AudioManager.playObjectSound("item");

                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name.StartsWith("Player"))
        {

            iscolliding = true;
            itemcanv.gameObject.SetActive(true);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.name.StartsWith("Player"))
        {
            iscolliding = false;
            itemcanv.gameObject.SetActive(false);
        }
    }
}
