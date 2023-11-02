using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMoveTo3rdRound : MonoBehaviour
{
    //variables 
    public float Jump;        //jump variable
    private float moveSpeed;  //speed of Player 
    bool onPlatform = false;  //Whether Player is on platform or not 
    private Rigidbody2D rb;   //to call RigidBody in script 
    public Vector2 Direction; //controls direction of movement 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //initializing the rigidbody to be used in FixedUpdate 
        moveSpeed = 5f; //how fast Player will move 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space)) //When Spacebar is pressed... 
        {
            if (onPlatform == true) //if Player is on a platform, 
            {
                //rb.velocity = Vector2.up * Jump; // when Space is pressed, player moves up
                rb.AddForce(Vector2.up * Jump);  //Player moves up 

                onPlatform = false; //Player off Platform 
            }

        }

        if (Input.GetKey(KeyCode.D))  //When D key is pressed..
        {
            //transform.position = new Vector2(transform.position.x + moveSpeed, transform.position.y); //move to the right 
            rb.AddForce(Vector2.right * moveSpeed);  //moving to the right 
            //rb.velocity = Vector2.right * moveSpeed; //(transform.position.x, transform.position.y); 

        }
        //else if (Input.GetKey(KeyCode.D) == false)
        //{
        //    Direction = Vector2.zero; 
        //}

        else if (Input.GetKey(KeyCode.A)) //When A key is pressed... 
        {
            //transform.position = new Vector2(transform.position.x - moveSpeed, transform.position.y); 
            //rb.velocity = -Vector2.right * moveSpeed; 
            rb.AddForce(-Vector2.right * moveSpeed); //moving to the left 

        }


    }
    void OnCollisionEnter2D(Collision2D collision) //adding colliders to have player land after jumping 
    {
        if (collision.gameObject.CompareTag("Platform"))  //if Player collides with Platform, 
        {
            if (onPlatform == false)  //and if Player is in air, 
            {
                onPlatform = true;  //Player will now land on ground 
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Coin") //check if other object tagged "Coin" 
        {
            //Debug.Log("Hit");
            SceneManager.LoadScene("3rdRound");  //next round 
        }
    }
}
