using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private GameObject player;

    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Abs(player.transform.position.x) < 50 )
        {
            gameObject.transform.position = new Vector3(0, player.transform.position.y, -2);
        }
        else
        {
            gameObject.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -2);
        }


    }
}
