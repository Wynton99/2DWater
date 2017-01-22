using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Movement : MonoBehaviour
{
    private Rigidbody2D ship;
    bool facingRight = false;

    //Use this for initialization

   void Start () {
        ship = GetComponent<Rigidbody2D>();
    }

    //Update is called once per frame

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        ship.velocity = new Vector2(horizontal * 30, ship.velocity.y);
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
}
