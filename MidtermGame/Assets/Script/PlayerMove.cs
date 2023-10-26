using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //variables 
    public float Jump;  
    private float moveSpeed;  //controls speed of Player 
    bool isGrounded = false;  //Whether player is on ground or not
    Rigidbody2D rb;  
    public Vector2 Direction; //controls direction of movement 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //initializing the rigidbody to be used in FixedUpdate 
        moveSpeed = 1f; //how fast Player will move 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space)) //When Spacebar is pressed... 
        {
            if (isGrounded == true) //if Player is on the platform, 
            {
                rb.AddForce(Vector2.up * Jump); //jump 
                isGrounded = false; //in air 
            }
        }

        if (Input.GetKeyDown(KeyCode.D))  //When D key is pressed..
        {
            //rb.velocity = new Vector2(rb.velocity.x, transform.position.y + moveSpeed); 
            Direction = Vector2.right * moveSpeed; 

        }

        else if (Input.GetKey(KeyCode.A)) //When A key is pressed...
        {
            //rb.velocity = new Vector2(rb.velocity.x, transform.position.y - moveSpeed); 
            Direction = Vector2.left * moveSpeed;
        }
    }
        void OnCollisionEnter2D(Collision2D collision) //adding colliders to have player land after jumping 
        {
            if (collision.gameObject.CompareTag("Platform"))  //if Player collides with Platform, 
            {
                if (isGrounded == false)  //and if Player is in air, 
                {
                    isGrounded = true;  //Player will now land on ground 
                }
            }
        }
}
