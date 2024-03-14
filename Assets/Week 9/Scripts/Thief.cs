using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : Villager
{
    public GameObject daggerPrefab;
    public Transform spawnDagger1;
    public Transform spawnDagger2;
    protected override void Attack()
    {
       
        base.Attack();
        
     destination = Camera.main.ScreenToWorldPoint(Input.mousePosition); //when RMB is pressed thief dashes towards the direction of the mouse
        transform.position = destination;
     Instantiate(daggerPrefab, spawnDagger1.position, spawnDagger1.rotation);
     Instantiate(daggerPrefab, spawnDagger2.position, spawnDagger2.rotation);  


    }
    public override ChestType CanOpen()
    {
        return ChestType.Thief;
    }
}
