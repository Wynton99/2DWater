using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class newMovement : MonoBehaviour
{

    private Rigidbody2D myRigidBody;
    private Rigidbody2D boatRigidBody;
    private Animator myAnimator;
    public Animator boatAnimator;
    private bool facingRight = true;
    public Text boatCommand;
    private bool erase = true;
    private int eraseTimer = 200;
    public GameObject boatObject;
    private SpriteRenderer mySprite;
    bool inBoat = false;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        boatAnimator = boatObject.GetComponent<Animator>();
        mySprite = GetComponent<SpriteRenderer>();
        boatRigidBody = boatObject.GetComponent<Rigidbody2D>();
        boatCommand.text = "";

    }

    void Update()
    {
        if (erase == true)
        {
            boatCommand.text = "";
        }

        if (eraseTimer > 0)
        {
            eraseTimer -= 1;
            if (eraseTimer == 0)
            {
                erase = true;
            }
        }

        handleMovement();

        if (Input.GetKeyDown(KeyCode.E))
        {
            toggleBoat();
        }

     //   if (Input.GetKeyDown(KeyCode.P))
      //  {
      //      toggleBoatSize();
      //  }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "invisWall")
        {
            eraseTimer = 200;
            boatCommand.text = "Press E to board \n and exit the boat";
            erase = false;
        }
    }

    void handleMovement()
    {
        Debug.Log("inBoat: " + inBoat);

        if (inBoat == false)
        {
            float horizontal = Input.GetAxis("Horizontal");

            myRigidBody.velocity = new Vector2(horizontal, myRigidBody.velocity.y);

            Debug.Log("Horizontal is: " + horizontal);

            myAnimator.SetFloat("speedAnimation", Mathf.Abs(horizontal));

            if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
            {
                facingRight = !facingRight;
                Vector3 theScale = transform.localScale;
                theScale.x *= -1;
                transform.localScale = theScale;
            }
        }
        else if (inBoat == true)
        {
            float horizontal = Input.GetAxis("Horizontal");
            Debug.Log("We are here2");
            Debug.Log("Horizontal is: " + horizontal);
            //boatRigidBody.velocity = new Vector2 (-1, 0);

            boatRigidBody.velocity = new Vector2(horizontal * 5, boatRigidBody.velocity.y);

            if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
            {
                facingRight = !facingRight;
                Vector3 theScale = transform.localScale;
                theScale.x *= -1;
                transform.localScale = theScale;
            }
        }


    }

    //void toggleBoatSize()
   // {
        //boatAnimator.SetBool("littleShipTrue", false);
   // }

    void toggleBoat()
    {

        if (inBoat == false && erase == false)
        {
            Debug.Log("We are entering the boat");
            //boatAnimator.ridingTrue = true;
            boatAnimator.SetBool("ridingTrue", true);
            mySprite.enabled = false;
            inBoat = true;
            erase = true;
        }

        else if (inBoat == true)
        {
            boatAnimator.SetBool("ridingTrue", false);
            mySprite.enabled = true;
            inBoat = false;
        }
    }
}

