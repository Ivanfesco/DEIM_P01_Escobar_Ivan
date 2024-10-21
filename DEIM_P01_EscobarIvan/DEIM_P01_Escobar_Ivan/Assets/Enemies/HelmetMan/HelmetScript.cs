using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class HelmetScript : MonoBehaviour
{
    public bool hasHelmet = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [SerializeField] private Rigidbody2D rbvar;
    [SerializeField] private ParentConstraint parentcont;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.name.StartsWith("BulletPrefab"))
        {
            if (hasHelmet)
            {
                parentcont.constraintActive = false;
                Destroy(collision.gameObject);
                transform.rotation = transform.rotation * Quaternion.Euler(new Vector3(0, 0, Random.Range(-45, 45)));
                rbvar.gravityScale = 1;
                rbvar.AddRelativeForce(new Vector2(Random.Range(1, 4), Random.Range(3, 7)), ForceMode2D.Impulse);
                hasHelmet = false;
                
            }
        }

    }

}
