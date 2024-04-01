using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    Rigidbody2D playerRB;
    public float speed = 15;
    Vector2 moving;
    public float jumpPower;
    bool grounded = true;
    Coroutine jumping;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moving.x = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && grounded == true)
        {
            
            grounded = false;

            jumpPower = 2300;

           
        }

        if(grounded == false && jumpPower >0)
        {
            jumpPower -= 2;
        }
        if(grounded == true && jumpPower > 0)
        {
            jumpPower -= 2;
        }



    }

    private void FixedUpdate()
    {

        playerRB.MovePosition(playerRB.position + (moving * speed * Time.deltaTime));
        playerRB.AddForce(Vector2.up * jumpPower * speed * Time.deltaTime);



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
