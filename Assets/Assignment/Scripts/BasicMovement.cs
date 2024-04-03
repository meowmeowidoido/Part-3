using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using Cinemachine;
//Abbas Haidari
//Basic Movement class as parents with two children that inherit from this main class.
public class BasicMovement : MonoBehaviour
{
    //Setting and calling variables
    public Rigidbody2D playerRB;
    public float speed = 15;
    protected Vector2 moving;
    public float jumpPower;
    public bool grounded = true; 
    // Start is called before the first frame update
    void Start()
    {
        //referencing rigidbody2D
        
    }

    // Update is called once per frame
    protected virtual void Update()//virtual is declared so that the function can be overrid in child script
    {
        //movement for X axis.
        moving.x = Input.GetAxis("Horizontal");

    

        //if space is held, and the player is grounded the jump variable will turn to 70.
        if (Input.GetKeyDown(KeyCode.Space) && grounded == true)
        {
            //grounded becomes false so player cannot jump in the air.
            grounded = false;

            jumpPower = 70;

           
        }

        //if grounded is false, and the jumpPower is greater than -200, decrease jumpPower
        //Makes it so that it feels less floaty when falling down.
        if(grounded == false && jumpPower >-200)
        {
            //multiplying by time.deltatime so it doesnt do it by frames but rather by the time that has passed
            jumpPower -= 200 *( 1f *Time.deltaTime);
          
        }
        //If jumpPower is greater than 1, and is grounded. Decrease.
        // this is for when the player is under a obstacle and is colliding with it. They will stay in the air.
        if(grounded == true && jumpPower > 1 )
        {
            //multiplying by time.deltatime so it doesnt do it by frames but rather by the time that has passed
            jumpPower -= 200* (1f * Time.deltaTime);
           
         
            
        }
        //if the player is grounded and jumpPower is less than 0,  reset value.
        //This is due to the fact that if the jumpPower is not reset
        //the player will walk very slowly and have sluggish movement

        if (grounded==true & jumpPower<0)
        {
            jumpPower = 0;
        }

        


    }
    //virtual is declared for later overriding.
    protected virtual void FixedUpdate()
    {
        //Moving the rigidbody and player.
        //using time.deltatime to make sure its done by seconds and not frames.
        playerRB.MovePosition(playerRB.position + (moving * speed * Time.deltaTime));
        //Vector2.Up is used to make the gameObject/rigidbody go up * multiplied by the speed 
        playerRB.AddForce(Vector2.up  * jumpPower * speed );
        //multiplied by the speed as well so that it feels smooth when running and jumping



    }

    //When colliding or staying in collision, grounded becomes true.
    private void OnCollisionStay2D(Collision2D collision)
    {
        grounded = true;
    }

    //when exiting grounded becomes false. (used for whenever the player jumps and is in the air so they cannot jump
    //more than once.
    private void OnCollisionExit2D(Collision2D collision)
    {
        grounded = false;
    }

 

}
