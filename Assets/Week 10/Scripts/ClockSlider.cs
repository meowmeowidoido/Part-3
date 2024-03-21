using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ClockSlider : MonoBehaviour
{
    public Slider clockSlider;
    float time;
    public float speed;
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime * speed;
        time = time % 60;
        clockSlider.value = time;
    }
}
