using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public Rigidbody2D playerRB;
    public float speed = 15;
    protected Vector2 moving;
    public  float jumpPower;
    public bool grounded = true;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        moving.x = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && grounded == true)
        {
            
            grounded = false;

            jumpPower = 70;

           
        }

        if(grounded == false && jumpPower >-200)
        {
            jumpPower -= 200 *( 1f *Time.deltaTime);
          
        }
        if(grounded == true && jumpPower > 1 )
        {
            jumpPower -= 200* (1f * Time.deltaTime);
           
         
            
        }
        if (grounded==true & jumpPower<0)
        {
            jumpPower = 0;
        }



    }

    protected virtual void FixedUpdate()
    {

        playerRB.MovePosition(playerRB.position + (moving * speed * Time.deltaTime));
        playerRB.AddForce(Vector2.up  * jumpPower * speed );



    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        grounded = true;
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        grounded = false;
    }

}
