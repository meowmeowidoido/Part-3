using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIForGame : MonoBehaviour
{
    public Slider energyBar;
    public static FlyingMovement EnergyDisplay { get; private set; }
    public static UIForGame Instance;
    void Update()
    {
        Instance = this;
        energyBar.value = this.energyBar.value;
    }
}
