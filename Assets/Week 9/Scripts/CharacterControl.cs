using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public  class CharacterControl : MonoBehaviour
{
    public TextMeshProUGUI displayCharacterRole;
    public static CharacterControl Instance;
    public static Villager SelectedVillager { get; private set; }

    private void Start()
    {
        Instance = this;
   Instance.displayCharacterRole.text = "None Selected";
    }
    public static void SetSelectedVillager(Villager villager)
    {
        if(SelectedVillager != null)
        {
            SelectedVillager.Selected(false); 
            Instance.displayCharacterRole.text = "None Selected";
        }
        SelectedVillager = villager;
        SelectedVillager.Selected(true);
     Instance.displayCharacterRole.text = villager.GetType().Name;
    }
   
    
}
