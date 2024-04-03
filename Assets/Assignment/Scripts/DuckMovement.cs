using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckMovement : BasicMovement
{
  
    Vector3 shrinkingT;//vector for shrinking scale values
    Vector3 originalScale;//vector for taking in the original scale value of the gameobject.
    bool boolShrink = false;//to detect whether the shrink is true/false
    bool boolEnlarge = false;//to detect whether the enlarging is true/false
    float powerStartup = 0;//starting up for loop in coroutine 
    Coroutine shrinkingOn;//coroutine for shrinking
    Coroutine enlargeOn;//coroutine for enlarging.
    private void Start()
    {
        //originalscale is set to gameobject local scale. So it can revert back once the player unshrinks or unenlargens
        originalScale = gameObject.transform.localScale;
        //setting values for shrinking scale.
        shrinkingT = new Vector3(2, 2f, 1f);

    }
    //overriding update.
    protected override void Update()
    {

      base.Update();


       //if left click is pressed, start enlarge on coroutine.
      if(Input.GetMouseButtonDown(1)) {
            //assigned a coroutine as a variable so it can easily be stopped and started.
            enlargeOn = StartCoroutine(enlargeDuck());
        
        
        }
      //if left click is released
       if(Input.GetMouseButtonUp(1))
        {
            boolEnlarge=false;//turn this variable false
            //revert the speed, jump and powerstartup variables
            speed = 10f;
            jumpPower = 70;
            powerStartup = 0;

            //if the coroutine is running, stop any other instances of the coroutine from running as well.
            //To keep performance good. 
            if (enlargeOn != null)
            { //assigned a coroutine as a variable so it can easily be stopped and started.
                StopCoroutine(enlargeOn);
            }
            //revert gravity scale.
            playerRB.gravityScale = 30;
            //revert gameobject scale.
            gameObject.transform.localScale = originalScale;
        }
    

        
    }

    //coroutine for shrinking.
    IEnumerator shrinking()
    {

        //while startup is less than 1.
        while (powerStartup < 1)
        {

            powerStartup += 1;
            //make speed 0 so the player cannot ove when this little "animation" is occuring
            speed = 0f;
            //repeatedly changes the scale of the gameObject to make it look like its transforming and then its shrinks.
            gameObject.transform.localScale = new Vector3(3, 3, 1f);
            yield return new WaitForSeconds(0.1f);//using wait for seconds to make it faster with 0.1f
            gameObject.transform.localScale = new Vector3(4, 4, 1f);
            yield return new WaitForSeconds(0.1f);
            gameObject.transform.localScale = new Vector3(3, 3f, 1f);
            yield return new WaitForSeconds(0.1f);
            //make the speed 20f since the scale is small and the player is really short
            speed = 20f;
            //make jumpPower 0 so it does not get crazy when the player is Jumping. (since the speed is already multiplying
            //in the addforce function for the rigidbody

            jumpPower = 0f;
          
            yield return null; 
        }
        //if the shrink is true
            while (boolShrink == true)
            {
            //make the gameobject the proper small size.
                gameObject.transform.localScale = shrinkingT;

                yield return null;




            }
        
     

    }

     IEnumerator enlargeDuck()
    {
        //enlarge becomes true.
        boolEnlarge = true;
        //while the powerStartup is less than two
        while (powerStartup < 2)
        {
            //perform this mini enlarging animation.
            powerStartup += 1;
            //same as shrinking, player cannot move when the animation is occuring.
            speed = 0f;
            gameObject.transform.localScale = new Vector3(6, 6, 1f);
            yield return new WaitForSeconds(0.1f);
            gameObject.transform.localScale = new Vector3(7,7, 1f);
            yield return new WaitForSeconds(0.1f);
            gameObject.transform.localScale = new Vector3(6, 6, 1f);
            yield return new WaitForSeconds(0.1f);
            gameObject.transform.localScale = new Vector3(8, 8, 1f);
            yield return new WaitForSeconds(0.1f);
            //reduce speed, so that the player cannot move really fast since they are enlarge and gigantic.
            speed = 5f;
            jumpPower = 0f;
            yield return null;
        }

        //if enlarge is true, make the gravity scale 10, 
        while (boolEnlarge == true)
        {//and enlarge the gameobject/player.
            playerRB.gravityScale = 10;
            gameObject.transform.localScale = new Vector3(20, 20, 1f);
            yield return null;
        }
    }
    //When the gameobject/player is clicked start the coroutine and turn shrink bool to true.
    private void OnMouseDown()
    {
        boolShrink = true;
        shrinkingOn = StartCoroutine(shrinking());
    }

    //if it is released revert all the variables regarding stats and turn boolShrink to false.
    private void OnMouseUp()
    {
        boolShrink= false;
        speed = 10f;
        jumpPower = 70;
        powerStartup = 0;
        //makes sure there are not more than 1 coroutine running 
       if (shrinkingOn != null)
        {
            StopCoroutine(shrinkingOn);
        }
       //reverts the gameobject scale back to the original size.
        gameObject.transform.localScale = originalScale;
    }

  
}
