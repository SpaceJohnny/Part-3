using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kenny : SpaceSquad
{
    //benny's code except instead of growing kenny shrinks
    public override void Eat()
    {
        StartCoroutine(Shrink());
    }

    private IEnumerator Shrink()
    {
        //transform.localScale.x * 0.5f instead of greater than 1 to shrink
        float targetScale = transform.localScale.x * 0.5f;
        float duration = 1f;
        float timer = 0f;

        while (timer < duration)
        {
            timer += Time.deltaTime;
            float scaleFactor = Mathf.Lerp(transform.localScale.x, targetScale, timer / duration);
            transform.localScale = new Vector3(scaleFactor, scaleFactor, 1f);
            yield return null;
        }
    }
}
