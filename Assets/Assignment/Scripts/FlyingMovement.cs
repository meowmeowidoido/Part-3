using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlyingMovement : BasicMovement
{
    //initializing variables 
    public float energy = 5;//used for energy and how long they can fly for
    public float flyPower;//flyPower intensity of flying up
    public bool inFlight = false;//detects whether player is in flightmode
    public Slider energyBar;//UI for energy and a bar
    //overriding update function from parent class
    protected override void Update()
    {
        //using base.Update() to allow for changes
        base.Update();
        //allowing the energyBar meter to take in the value of energy float variable
        energyBar.value = energy;
        //jump power is set to 0, flying movement does not allow jumps.
        jumpPower=0;
        //if the W key is pressed and the energy meter is greater than 0,
        // the player can fly. Energy must be greater than 0 so the player cannot infinitely fly up to the sky.
        if (Input.GetKeyDown(KeyCode.W) && energy>0)
        {
            //inflight is turned on
            inFlight = true;
            //flypower is set to 700.
            flyPower = 700;  

        }
        //if in flight is false or the key is released turn inflight off.
        if (Input.GetKeyUp(KeyCode.W) || inFlight == false)
        {
            inFlight = false;
            //if the flyPower is greater than 0, decrement so that it causes the
            //the player to fall drastically.
            if (flyPower > 0)
            {
                flyPower -= 100;
            }
        }
        //if the energy is 0, flyPower begins going down. (causing player to fall)
        if (energy<=0)
        {
            flyPower -= 10;
        }

        //if the player is not grounded and the energy is greater than 0
        //lose energy when the player is flying.
        if (grounded == false && energy >0)
        {
            energy -= 1* Time.deltaTime;
        }

        if (energy < 0)
        {
            energy = 0;
        }
        //if the player is grounded restore energy by a second.
        // Max energy is five seconds.
        if (grounded == true)
        {
            if(energy<5)  energy += 1 *Time.deltaTime;
        }
    }
    //overiding the fixedupdate to change the movement.
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        playerRB.AddForce(playerRB.position + Vector2.up * flyPower);

    }
  
}
