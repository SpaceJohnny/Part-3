using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//code based off week 9
public enum FoodType { Benny, Lenny, Kenny, Jenny }
public class Food : MonoBehaviour
{
    //used for reference, objects with the script SpaceSquad
    private SpaceSquad spaceSquad;

    public FoodType whoCanEat;

    //if the circles (food) gets "eaten" (collides), the spacesquad should have their speed increased by 1
    //after the circles gets eaten, the gameobject should be destroyed 
    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        spaceSquad = other.GetComponent<SpaceSquad>();

        if (spaceSquad != null)
        {
            if (spaceSquad.MatchingFood == whoCanEat)
            {
                //changed to use the Eat method 
                //spaceSquad.Speed += 1f;
                spaceSquad.Eat();

                Destroy(gameObject);
            }
        }
    }
}
