using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraHolder : MonoBehaviour
{
   //Public static variable for the cinemachine camera
    public static CinemachineVirtualCamera focusingCamera;

    private void Start()
    {//get component is needed for the gameobject the camera is on, without this it will not work.
        focusingCamera = GetComponent<CinemachineVirtualCamera>();
    }

    public static float currentIndex = 0;
    //Setting the currentIndex to 0.
 
    public static void SwitchCharacterFocus()
    {
        //this increments whenever the function is called, and the index goes from 1-3
        //once it becomes 4 it will reset back to 1 and go back to the ghost.
        //makes sure it never goes over 3 as well.
        currentIndex +=1;
        if (currentIndex == 4)
        {
            currentIndex = 1;
        }
    }
}