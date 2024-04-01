using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FlyingMovement : BasicMovement
{

    public float energy = 5;
    public float flyPower;
    public bool inFlight = false;
    protected override void Update()
    {
        
        base.Update();

        jumpPower=0;
        if (Input.GetKeyDown(KeyCode.W) && energy>0)
        {
            inFlight = true;
            flyPower = 20000;  

        }
        if (Input.GetKeyUp(KeyCode.W) || inFlight == false)
        {
            inFlight = false;
            if (flyPower > 0)
            {
                flyPower -= 100;
            }
        }
        if (energy<=0)
        {
            flyPower -= 10;
        }

        if (grounded == false && energy >0)
        {
            energy -= 1* Time.deltaTime;
        }

        if (grounded == true)
        {
            if(energy<5)  energy += 1 *Time.deltaTime;
        }
    }
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        playerRB.AddForce(playerRB.position + Vector2.up * flyPower * Time.deltaTime);

    }

   
}
