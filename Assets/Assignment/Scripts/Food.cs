using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    //used for reference, objects with the script SpaceSquad
    private SpaceSquad spaceSquad;

    //if the circles (food) gets "eaten" (collides), the spacesquad should have their speed increased by 1
    //after the circles gets eaten, the gameobject should be destroyed 
    private void OnTriggerEnter2D(Collider2D other)
    {
        spaceSquad = other.GetComponent<SpaceSquad>();

        if (spaceSquad != null)
        {
            spaceSquad.Speed += 1f;

            Destroy(gameObject);
        }
    }
}
