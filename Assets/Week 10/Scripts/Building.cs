using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    // Start is called before the first frame update
   public GameObject grainbox;
   public  GameObject cauldron;
    public GameObject basket;
    public GameObject building;
    float interpolate;
    float time = 0;
    void Start()
    {

   Instantiate(basket, building.transform);
        Instantiate(cauldron, building.transform);
        Instantiate(grainbox, building.transform);
        StartCoroutine(BuildingAll());

    }
  IEnumerator BuildingAll()
    {

        while (time < 1) ;
        {
            interpolate = time / 1;
            
            Debug.Log(time);
      //    building.transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, interpolate); //works perfectly fine with this
            basket.transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, interpolate);
            yield return new WaitForSeconds(interpolate / 2);
            cauldron.transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, interpolate);
            yield return new WaitForSeconds(interpolate / 3);
            grainbox.transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, interpolate);
            time += Time.deltaTime;
           
            
        }
        

    }
 
    
}
