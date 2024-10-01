using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    public bool inputallowed = true;
    [SerializeField] private SpriteRenderer spriterender;
    [SerializeField] private Rigidbody2D rigidbod;
    [SerializeField] private int speed = 5;
    [SerializeField] private int jumpspeed = 300;
    [SerializeField] private Collider2D groundcol;
    [SerializeField] private TilemapCollider2D tilecol;
    [SerializeField] private Animator animatorvar;

    private bool grounded = false;
    private float yvelocity = 0;
    private float xvelocity = 0;
    private int maxvel = 10;
    private float extragravity = 0.5f;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        yvelocity = rigidbod.velocity.y;
        xvelocity = rigidbod.velocity.x;


        // limit max velocity
        rigidbod.velocity = new Vector2 (Mathf.Clamp(xvelocity, -maxvel, maxvel), yvelocity);

        ///////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////INPUT ZONE///////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////
        if (inputallowed)
        {
            if (Input.GetKey(KeyCode.D))
            {
                rigidbod.AddForce(Vector2.right * speed);
                spriterender.flipX = false;
                animatorvar.SetBool("IsRunning", true);
            }
            else if (Input.GetKeyUp(KeyCode.D))
            {

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
            
        }
        ////////////////////////////////////////////////////////////////////


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


        animatorvar.SetBool("IsRunning", rigidbod.velocity.x != 0);



        //Extra gravity
        if (yvelocity <0)
        {

            rigidbod.AddForce(Vector2.down * extragravity);

        }



    }

    public void restartscene()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
