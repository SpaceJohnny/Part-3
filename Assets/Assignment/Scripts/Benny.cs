using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Benny : SpaceSquad
{
    //using eat override to make benny increase in size 
    public override void Eat()
    {
        //using coroutine to make the growing effect
        //the increase in size happens within a second
        StartCoroutine(Grow());
    }

    private IEnumerator Grow()
    {
        //benny is scaled up by 30% 
        float targetScale = transform.localScale.x * 1.3f; 
        float duration = 1f;
        float timer = 0f;

        while (timer < duration)
        {
            //makes sure the frames are updated slowly instead of using framerate 
            timer += Time.deltaTime;
            //gradually increase benny's size using lerp
            float scaleFactor = Mathf.Lerp(transform.localScale.x, targetScale, timer / duration);
            transform.localScale = new Vector3(scaleFactor, scaleFactor, 1f);

            yield return null;
        }
    }
}
