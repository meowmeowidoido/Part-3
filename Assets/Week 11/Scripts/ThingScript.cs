using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThingScript : MonoBehaviour
{
    public static float staticNumber;
    public float notStatic;
    void Start()
    {
        staticNumber = Random.Range(1, 10);
        notStatic = Random.Range(1, 10);

        Debug.Log(this.ToString() + " Static Number: " + staticNumber + " Not Static: " + notStatic);
    }
}