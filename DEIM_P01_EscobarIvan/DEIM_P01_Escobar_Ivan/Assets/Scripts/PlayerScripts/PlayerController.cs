using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    public Sprite[] spriteArray;
    [SerializeField] private SpriteRenderer spriterender;
    [SerializeField] private Rigidbody2D rigidbod;
    [SerializeField] private float speed = 20;
    [SerializeField] private float jumpspeed = 300;
    [SerializeField] private Collider2D groundcol;
    [SerializeField] private TilemapCollider2D tilecol;
    [SerializeField] private Animator animatorvar;

    private bool grounded = false;
    private float yvelocity = 0;
    private float xvelocity = 0;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        yvelocity = rigidbod.velocity.y;
        xvelocity = rigidbod.velocity.x;

        // Limit max speed
        if(rigidbod.velocity.x >= 10)
        {
            rigidbod.velocity = new Vector2(10,yvelocity);
        }
        // limit min speed
        if (rigidbod.velocity.x <= -10)
        {
            rigidbod.velocity = new Vector2(-10, yvelocity);
        }



        
        if (Input.GetKey(KeyCode.D))
        {
            rigidbod.AddForce(Vector2.right * speed);
            spriterender.flipX = false;
            animatorvar.SetBool("IsRunning", true);
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            ////////////////////////////////////////////////
            //rigidbod.AddForce(Vector2.left * speed * 75);
            ////////////////////////////////////////////////

            animatorvar.SetBool("IsRunning", false);

            // paro en seco VV
            rigidbod.velocity = new Vector2(0, yvelocity);

        }



        if (Input.GetKey(KeyCode.A))
        {
            rigidbod.AddForce(Vector2.left * speed);
            spriterender.flipX = true;
            animatorvar.SetBool("IsRunning", true);
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {

            //////////////////////////////////////////////////
            //rigidbod.AddForce(Vector2.right * speed * 75);
            ///////////////////////////////////////////////////

            animatorvar.SetBool("IsRunning", false);

            //paro en seco VV
            rigidbod.velocity = new Vector2(0, yvelocity);

        }


        //Salto

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded == true)
            {
                rigidbod.AddForce(Vector2.up * jumpspeed);
            }
        }

        //Check para saber si se está tocando el suelo

        if (groundcol.IsTouching(tilecol))
        {
            grounded = true;
            animatorvar.SetBool("IsGrounded", true);

        }
        else
        {
            grounded = false;
            animatorvar.SetBool("IsGrounded", false);

        }
    }
}
