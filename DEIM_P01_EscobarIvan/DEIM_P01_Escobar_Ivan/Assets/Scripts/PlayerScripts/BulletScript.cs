using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class BulletScript : MonoBehaviour
{

    [SerializeField] private BoxCollider2D boxcol;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector2.down * 3 * Time.deltaTime);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {



    }
}

