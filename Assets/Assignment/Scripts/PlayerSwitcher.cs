using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwitcher : MonoBehaviour
{
    //gameobjects needed to switch between them and set them active
    public GameObject ghost;
    public GameObject rabbit;
    public GameObject duck;
    //transform that follows the gameobjects transform.
    public Transform followPoint;
    private void Start()
    {
        //Instructions on how to move around.
        print("CLICK FOR MORE INFO: Movement Test:\nGhost Controls: W to fly, A and D to move left and " +
            "right\nDuck Controls: Hold Mouse 1 on DUCK to shrink! " +
            "Release to Unshrink/Unlarge, use right mouse button to Enlarge\nNormal Controls: A and D to move left and right, Space to Jump, Left Shift to switch characters!");
    }
    private void Update()
    {
        //Keypressing detecting, whenever the player presses leftshift it detects and calls the FocusSwitch variable
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            //switches to another character/game object
            FocusSwitch(followPoint);
        }
       
    }
    public void FocusSwitch(Transform newPoint) 
    {
        //calls cameraHolder static class and function switchcharacterfocus
        CameraHolder.SwitchCharacterFocus();
        //if the variable index for it is 1 it will change to the ghost.
        if (CameraHolder.currentIndex == 1)
        {
            //followPoint transform holds the ghost transform 
            followPoint = ghost.transform.parent;
            //ghost becomes active in hierchary and game
            ghost.SetActive(true);
            //the remaining game objects become invisible/non active
            rabbit.SetActive(false);
            duck.SetActive(false);
            //if the followPoint equals to the ghost.transform
            if (followPoint=ghost.transform)
            {
                //then make the camera follow the FollowPoint.transform
                //basically camera follows the ghost!
                CameraHolder.focusingCamera.Follow = followPoint.transform;
            }



        }
        if (CameraHolder.currentIndex == 2)
        {
            //if the index is two do the same thing but for the rabbit.
            //followpoint takes rabbit transform.
            followPoint = rabbit.transform.parent;
            //ghost and duck become false. So the player doesnt accidentally move them when they are focused on another character.
            ghost.SetActive(false);
            duck.SetActive(false);
            //rabbit becomes true!
            rabbit.SetActive(true);
            //if the followpoint is the same as rabbit transform make the camera follow the followPoint  transform
            //aka make it follow the rabbit!
            if (followPoint=rabbit.transform)
            {
                CameraHolder.focusingCamera.Follow = followPoint.transform;
            }



        }
        if (CameraHolder.currentIndex == 3)
        {//Same idea with duck.
            followPoint = duck.transform.parent;
            //setting duck to true
            duck.SetActive(true);
            //others are false
            rabbit.SetActive(false);
            ghost.SetActive(false);
            //followpoint is now duck transform.
            if (followPoint=duck.transform)
            {
                //Cinemachine camera is now following the followpoint transform
                //which in turn follows the duck gameobject.
                CameraHolder.focusingCamera.Follow= followPoint.transform;
            }
            
        }
    }

}
