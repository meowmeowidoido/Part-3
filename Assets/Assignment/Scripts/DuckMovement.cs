using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckMovement : BasicMovement
{
  
    Vector3 crouchingT;
    Vector3 originalScale;
    bool boolShrink = false;
    bool boolEnlarge = false;
    float powerStartup = 0;
    Coroutine shrinkingOn;
    Coroutine enlargeOn;
    private void Start()
    {
        //  boxCollider = GetComponent<BoxCollider2D>();
        // originalSize.offset = boxCollider.offset;
        originalScale = gameObject.transform.localScale;
        crouchingT = new Vector3(2, 2f, 1f);

    }
    protected override void Update()
    {

      base.Update();
          
      if(Input.GetMouseButtonDown(1)) {

            enlargeOn = StartCoroutine(enlargeDuck());
        
        
        }
       if(Input.GetMouseButtonUp(1))
        {
            boolEnlarge=false;
            
            speed = 10f;
            jumpPower = 70;
            powerStartup = 0;
            if (enlargeOn != null)
            {
                StopCoroutine(enlargeOn);
            }
            playerRB.gravityScale = 30;
            gameObject.transform.localScale = originalScale;
        }
    

        
    }

    IEnumerator shrinking()
    {
      
        while (powerStartup < 1)
        {
            powerStartup += 1;
            speed = 0f;
            gameObject.transform.localScale = new Vector3(3, 3, 1f);
            yield return new WaitForSeconds(0.1f);
            gameObject.transform.localScale = new Vector3(4, 4, 1f);
            yield return new WaitForSeconds(0.1f);
            gameObject.transform.localScale = new Vector3(3, 3f, 1f);
            yield return new WaitForSeconds(0.1f);
            speed = 20f;
            jumpPower = 0f;
            yield return null;
        }
            while (boolShrink == true)
            {

                gameObject.transform.localScale = crouchingT;

                yield return null;




            }
        
     

    }

     IEnumerator enlargeDuck()
    {
        boolEnlarge = true; 
        while (powerStartup < 2)
        {
            powerStartup += 1;
            speed = 0f;
            gameObject.transform.localScale = new Vector3(6, 6, 1f);
            yield return new WaitForSeconds(0.1f);
            gameObject.transform.localScale = new Vector3(7,7, 1f);
            yield return new WaitForSeconds(0.1f);
            gameObject.transform.localScale = new Vector3(6, 6, 1f);
            yield return new WaitForSeconds(0.1f);
            gameObject.transform.localScale = new Vector3(8, 8, 1f);
            yield return new WaitForSeconds(0.1f);
            speed = 5f;
            jumpPower = 0f;
            yield return null;
        }

        while (boolEnlarge == true)
        {
            playerRB.gravityScale = 10;
            gameObject.transform.localScale = new Vector3(20, 20, 1f);
            yield return null;
        }
    }
    private void OnMouseDown()
    {
        boolShrink = true;
        shrinkingOn = StartCoroutine(shrinking());
    }

    private void OnMouseUp()
    {
        boolShrink= false;
        speed = 10f;
        jumpPower = 70;
        powerStartup = 0; 
       if (shrinkingOn != null)
        {
            StopCoroutine(shrinkingOn);
        }

        gameObject.transform.localScale = originalScale;
    }
   
}
