using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private GameObject player;
    Vector3 target;
    // Start is called before the first frame update
    private void Start()
    {
        player = FindAnyObjectByType<PlayerController>().gameObject ;
        gameObject.transform.position = new Vector3(0, player.transform.position.y, -2);

    }

    // Update is called once per frame
    void Update()
    {
        print(gameObject.transform.position.y - target.y);
        target = new Vector3(0, player.transform.position.y + player.GetComponent<Rigidbody2D>().velocity.y / 10, -2);
        if (Mathf.Abs(player.transform.position.x) < 50 )
        {
            //     gameObject.transform.position = new Vector3(0, player.transform.position.y + player.GetComponent<Rigidbody2D>().velocity.y / 10, -2);
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, target, gameObject.transform.position.y - target.y / 100);
        }
        else
        {
            gameObject.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -2);
        }


    }
}
