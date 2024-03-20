using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : Villager
{
    public GameObject knifePrefab;
    public Transform spawnPoint1;
    public Transform spawnPoint2;

    //adding a timer to dash
    //float timerValue;

    //public float dashTimer = 2;
    public float dashSpeed = 7;

    //when is the code done with dash? 
    // bool isDashing;

    Coroutine dashing;

    protected override void Attack()
    {
        //dash towards mouse
        destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (dashing != null )
        {
            StopCoroutine(dashing);
            //StopAllCoroutines():
        }
        StartCoroutine(Dash());
        

        //isDashing = true;
        ////initiallize timer value
        //timerValue = dashTimer;

        speed = 7;
    }

    IEnumerator Dash()
    {
        //timerValue -= Time.deltaTime;
        //if(timerValue < 0)
        //{
        //    isDashing = false;
        //    speed -= dashSpeed;

        //moved from void Attack()

        //waiting until the timer passes to play attack animation
        speed += dashSpeed;
        while(speed > 3)
        {
            yield return null;
        }

        base.Attack();
        yield return new WaitForSeconds(0.1f);
         Instantiate(knifePrefab, spawnPoint1.position, spawnPoint1.rotation);
        yield return new WaitForSeconds(0.1f);
        Instantiate(knifePrefab, spawnPoint2.position, spawnPoint2.rotation);
    }

    ////overriding update
    //protected override void Update()
    //{
    //    //base allows it to work in respondance
    //    base.Update();
    //    if(isDashing == true)
    //    {
    //        Dash();
    //    }
    //}

    public override ChestType CanOpen()
    {
        return ChestType.Thief;
    }
}
