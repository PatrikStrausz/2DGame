using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;


public class Player : MonoBehaviour
{

    private Rigidbody2D rb;

    public float speed;

    public LayerMask groundMask;


   
    public GameObject onGround;
    public bool isGrounded;
    public float checkRadius;

    private bool facingRight;


    public bool canJump = true;

    public float jumpForce = 0.0f;
   

    public Vector2 direction;

    public ParticleSystem jumpDust;

    public float moveInput;

    public ParticleSystem footsteps;
    private ParticleSystem.EmissionModule footEmission;

    private bool wasOnGround;

    Vector3 lastVelocity;

    public int jumpCounter;

   


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        footEmission = footsteps.emission;
    }


    void Start()
    {

      

        transform.position = new Vector3(PlayerPrefs.GetFloat("X"), PlayerPrefs.GetFloat("Y"), PlayerPrefs.GetFloat("Z"));

        jumpCounter = PlayerPrefs.GetInt("Jumps");



       
    }
    
    
    void Update()
    {
        
       
   
        
        isGrounded = Physics2D.OverlapCircle(onGround.transform.position,checkRadius, groundMask);

        moveInput = Input.GetAxisRaw("Horizontal");

     
    
        //If on ground move horizontaly
        if(jumpForce == 0.0f && isGrounded)
        {
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
          
        }
      
        //While holding space jump force increases
        if(Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0) && isGrounded && canJump)
        {
            if (isGrounded)
            {
                jumpForce += 0.2f;
                rb.velocity = Vector2.zero;
            }
        }

        //On space released jump
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) && isGrounded && canJump)
        {
           
            rb.velocity = new Vector2(0, rb.velocity.y);
          
          
           
        }
       

        //Set max jumpforce to 25
        if (jumpForce >= 25f ){
            jumpForce = 25;
        }


       

        //Jump
        if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0))
        {
            if (isGrounded )
            {
                rb.velocity = new Vector2(moveInput * speed,jumpForce );
                jumpForce = 0;

                jumpCounter += 1;
                JumpsCounter.jumpValue = jumpCounter;
                CreateJumpDust();
            }
           
            canJump = false;
        }
       

        if (isGrounded)
        {
            canJump = true;
        }

       //Flipping sprite

        if (Input.GetAxis("Horizontal") < 0 && !facingRight)
        {
           
            Flip();
        }
        else if (Input.GetAxis("Horizontal") > 0 && facingRight)
        {
            Flip();
        }


        //Footstep particle
        if(Input.GetAxisRaw("Horizontal") != 0 && isGrounded)
        {
            footEmission.rateOverTime = 35;
        }
        else
        {
            footEmission.rateOverTime = 0;
        }


        //show impact effect
        if(!wasOnGround && isGrounded)
        {
            jumpDust.Stop();
            jumpDust.Play();
        }
        wasOnGround = isGrounded;

        lastVelocity = rb.velocity;
    }



    void CreateJumpDust()
    {
        jumpDust.Play();
    }

    void Flip()
    {
        facingRight = !facingRight;

        
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        direction.x *= -1;
        transform.localScale = theScale;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
         
        
            var speed = lastVelocity.magnitude;
            var s = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);

            if(speed > 16f)
            {
                speed = 16f;
            }
            rb.velocity = s * Mathf.Max(speed, 0f);
           
        }
    }



    /*public void LoadPlayer()
    {

        PlayerData data = SaveSystem.LoadPlayer();

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;


        Debug.Log("Player position: " + position);
    }
    */
   


    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(onGround.transform.position,0.3f);
    }




}
