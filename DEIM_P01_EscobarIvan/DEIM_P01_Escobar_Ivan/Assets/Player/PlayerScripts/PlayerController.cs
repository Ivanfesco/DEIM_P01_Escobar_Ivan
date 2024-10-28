using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    public bool inputallowed = true;
    [SerializeField] private SpriteRenderer spriterender;
    [SerializeField] private Rigidbody2D rigidbod;
    [SerializeField] private Collider2D groundcol;
    [SerializeField] private Animator animatorvar;
    [SerializeField] private GameObject GameObjectToSpawn;
    [SerializeField] private InventoryScript inventorymanagerref;
    [SerializeField] private float maxjumptime=0.9f;
    [SerializeField] public int speed = 5;
    [SerializeField] private int jumpspeed;
    [SerializeField] private int recoilspeed = 200;
    [SerializeField] private ParticleSystem footparticlesR;
    [SerializeField] private ParticleSystem footparticlesL;
    [SerializeField] private ParticleSystem bulletParticle;
    private float jumpTime=0;
    private int colidingwith = 0;
    private bool grounded = false;
    private float yvelocity = 0;
    private float xvelocity = 0;
    public int maxvel = 10;
    private float extragravity = 0.5f;
    private bool jumping;
    private bool impulseapplied;
    public int damage = 1;
    public bool hasBulletPenetration;
    public int amountOfBulletsToSpawn = 1;
    private UnityEngine.SceneManagement.Scene scene;


    // Start is called before the first frame update
    private void Awake()
    {
        scene = SceneManager.GetActiveScene();
        if (scene.name.StartsWith("Desert") || scene.name.StartsWith("Forest") || scene.name.StartsWith("Tundra"))
        {
            
            gameObject.transform.position = new Vector3(0, -20, 0);
        }
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);
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
                rigidbod.AddForce(Vector2.right * speed * Time.fixedDeltaTime * 25);
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
                rigidbod.AddForce(Vector2.left * speed * Time.fixedDeltaTime * 25);
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
                    footparticlesL.Play();
                    footparticlesR.Play();
                    impulseapplied = false;
                    rigidbod.velocity=(new Vector2(rigidbod.velocity.x, Vector2.up.y * jumpspeed));
                    jumping=true;
                    jumpTime=0;
                }
                else
                {
                    if (inventorymanagerref.bulletAmount >= 1)
                    {
                        bulletParticle.Play();
                        inventorymanagerref.bulletAmount = inventorymanagerref.bulletAmount - 1;
                        //halve vertical velocity, add impulse up 
                        rigidbod.velocity = new Vector2(rigidbod.velocity.x, rigidbod.velocity.y / 2);

                        rigidbod.AddForce(Vector2.up * recoilspeed * Time.fixedDeltaTime * inventorymanagerref.bulletAmount * 10);

                        //spawn bullet
                        for (int i = 0; i < amountOfBulletsToSpawn; i++)
                        {
                            Instantiate(GameObjectToSpawn, new Vector2(transform.position.x, transform.position.y - 1), transform.rotation * Quaternion.Euler(new Vector3(0, 0, Random.Range(-5, 5))));
                        }
                    }
                }
            }
            if (Input.GetKeyUp(KeyCode.Space) || (jumpTime >= maxjumptime))
            {
                if(rigidbod.velocity.y >= 2)
                {
                    if (!impulseapplied)
                    {
                        impulseapplied = true;
                        rigidbod.velocity = new Vector2(rigidbod.velocity.x, 3);
                    }
                }
                
            }

            if (jumping)
            {
                jumpTime += Time.fixedDeltaTime;
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
            inventorymanagerref.bulletAmount = inventorymanagerref.maxBulletAmount;
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
                if (collision.CompareTag("Enemy"))
                {
                    if (collision.GetComponent<DeathManager>().stompable)
                    {
                        rigidbod.velocity = new Vector2(rigidbod.velocity.x, 0);
                        rigidbod.AddForce(new Vector2(0, 250));
                        collision.GetComponent<DeathManager>().damage();
                    }
                }
                footparticlesL.Play();
                footparticlesR.Play();
                grounded = true;
                jumping = false;
                jumpTime = 0;
                
            }
            else
            {
                grounded = false;
                jumping =true;
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
                jumping = false;
                jumpTime = 0;
                
            }
            else
            {
                jumping = true;
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
