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
    [SerializeField] private int recoilspeed = 200;
    [SerializeField] private Collider2D groundcol;
    [SerializeField] private Animator animatorvar;
    [SerializeField] private GameObject GameObjectToSpawn;

    private int colidingwith = 0;
    private bool grounded = false;
    private float yvelocity = 0;
    private float xvelocity = 0;
    private int maxvel = 10;
    private float extragravity = 0.5f;
    private int bulletAmount = 10;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        yvelocity = rigidbod.velocity.y;
        xvelocity = rigidbod.velocity.x;
        if(Input.GetKeyDown(KeyCode.R))
        {
            restartscene();
        }

        // limit max velocity
        rigidbod.velocity = new Vector2 (Mathf.Clamp(xvelocity, -maxvel, maxvel), yvelocity);

        ///////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////INPUT ZONE///////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////
        if (inputallowed)
        {
            if (Input.GetKey(KeyCode.D))
            {
                rigidbod.AddForce(Vector2.right * speed * Time.deltaTime * 100);
                spriterender.flipX = false;
                animatorvar.SetBool("IsRunning", true);
            }
            else if (Input.GetKeyUp(KeyCode.D))
            {

                // paro en seco VV
                rigidbod.velocity = new Vector2(2, yvelocity);

            }



            if (Input.GetKey(KeyCode.A))
            {
                rigidbod.AddForce(Vector2.left * speed * Time.deltaTime * 100);
                spriterender.flipX = true;
                animatorvar.SetBool("IsRunning", true);
            }
            else if (Input.GetKeyUp(KeyCode.A))
            {
                //paro en seco VV
                rigidbod.velocity = new Vector2(-2, yvelocity);

            }


            //Salto

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (grounded == true)
                {
                    rigidbod.AddForce(Vector2.up * jumpspeed);
                }
                else
                {
                    if (bulletAmount >= 1)
                    {
                        bulletAmount = bulletAmount - 1;
                        //halve vertical velocity, add impulse up 
                        rigidbod.velocity = new Vector2(rigidbod.velocity.x, rigidbod.velocity.y/2);
                       
                        rigidbod.AddForce(Vector2.up * recoilspeed * Time.deltaTime * bulletAmount, ForceMode2D.Impulse);
                        
                        //spawn bullet
                        Instantiate(GameObjectToSpawn, new Vector2(transform.position.x, transform.position.y - 1), transform.rotation * Quaternion.Euler(new Vector3(0, 0, Random.Range(-5, 5))));

                    }
                }
            }
            
        }
        ////////////////////////////////////////////////////////////////////






        animatorvar.SetBool("IsRunning", Mathf.Abs(0 - rigidbod.velocity.x) >= 0.01);

        animatorvar.SetBool("IsJumping", yvelocity>=0.01);

        //Extra gravity
        if (yvelocity <0)
        {

            rigidbod.AddForce(Vector2.down * extragravity);

        }
        
        if (colidingwith <= 0)
        {
            colidingwith = 0;
        }


        animatorvar.SetBool("IsGrounded", grounded);
        if (grounded == true)
        {
            bulletAmount = 10;
        }

    }
    //Check para saber si se está tocando el suelo
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger == false)
        {
            colidingwith = colidingwith + 1;
            if (colidingwith >= 1)
            {
                grounded = true;
            }
            else
            {
                grounded = false;

            }
        }
        
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.isTrigger == false)
        {
            colidingwith = colidingwith - 1;
            if (colidingwith >= 1)
            {
                grounded = true;

            }
            else
            {

                grounded = false;

            }
        }
    }

    /// 
    /// 
    /// 
    
    public void restartscene()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
