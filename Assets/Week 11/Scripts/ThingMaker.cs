using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThingMaker : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject thingPrefab;
    List <ThingScript> thingList= new List <ThingScript> ();    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
           GameObject go =  Instantiate(thingPrefab);
            thingList.Add(go.GetComponent<ThingScript>());

        }

        foreach(ThingScript thing in thingList)
        {
            Debug.Log(thing.ToString() + " " + ThingScript.staticNumber);
        }


        

    }
}
