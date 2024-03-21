using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Thief : Villager
{
    public GameObject daggerPrefab;
    public Transform spawnDagger1;
    public Transform spawnDagger2;
    Coroutine dashing;
    protected override void Attack()
    {
        if (dashing != null)
        {
            StopCoroutine(dashing); 
        }
        dashing = StartCoroutine(Dash());
    }
    IEnumerator Dash()
    {
        destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);//when RMB is pressed thief dashes towards the direction of the mouse
        speed = 7;
        while (speed >3)
        {
            yield return null;
        }
     
            base.Attack();
        yield return new WaitForSeconds(0.1f);
        Instantiate(daggerPrefab, spawnDagger1.position, spawnDagger1.rotation);
        yield return new WaitForSeconds(0.2f);
        Instantiate(daggerPrefab, spawnDagger2.position, spawnDagger2.rotation);
        
      
    }
  /*  protected override void Update()
    {
        base.Update();
        if(isDashing==true)
        {
            Dash();
            
        }
    }*/
    public override ChestType CanOpen()
    {
        return ChestType.Thief;
    }
}
