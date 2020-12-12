using UnityEngine;


public class PlayerMovement : MonoBehaviour
{



    private Vector2 moveX;
    private Vector2 moveY;

    public float horizontalMovement;
    public float verticalMovement;

    public float moveSpeed;
    public bool playerMoveable;

    public Animator anim;
    private Rigidbody2D playerRb;

    void Start()
    {
        anim = GetComponent<Animator>();
        playerRb = gameObject.GetComponent<Rigidbody2D>();

        playerMoveable = true;

        moveX = new Vector2(playerRb.position.x, 0.0f);
        moveY = new Vector2(0.0f, playerRb.position.y);
    }

    void Update()
    {
        //get input
        horizontalMovement = Input.GetAxisRaw("Horizontal");

        verticalMovement = Input.GetAxisRaw("Vertical");
       
    }

    void FixedUpdate()
    {


        //playermovement
        if (playerMoveable)
        {
            //set new vectors when input
            if (horizontalMovement >= 0.5f || horizontalMovement <= -0.5f)
            {
                moveX = (playerRb.position + new Vector2(horizontalMovement * moveSpeed * Time.fixedDeltaTime, 0.0f));
                anim.SetFloat("horizontalMoveLast", horizontalMovement);
                anim.SetFloat("verticalMoveLast", 0);

            }

            if (verticalMovement >= 0.5f || verticalMovement <= -0.5f)
            {
                moveY = playerRb.position + new Vector2(0.0f, verticalMovement * moveSpeed * Time.fixedDeltaTime);
                anim.SetFloat("verticalMoveLast", verticalMovement);
                anim.SetFloat("horizontalMoveLast", 0);
            }

            //set animator isMoving
            if (horizontalMovement >= 0.5f || horizontalMovement <= -0.5f || verticalMovement >= 0.5f || verticalMovement <= -0.5f)
            {
                anim.SetBool("isMoving", true);
            }
            else
            {
                anim.SetBool("isMoving", false);

            }


            playerRb.MovePosition(new Vector2(moveX.x, moveY.y));

            //set animations
            anim.SetFloat("horizontalMove", horizontalMovement);
            anim.SetFloat("verticalMove", verticalMovement);


        }
        else 
        {
            anim.SetFloat("verticalMove", 0);
            anim.SetFloat("horizontalMove", 0);
        }
    }
}
