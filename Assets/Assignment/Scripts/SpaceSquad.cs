using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SpaceSquad : MonoBehaviour
{
    //SpriteRenderer sr;
    Rigidbody2D rb;

    bool clickingOnSelf;
    bool isSelected;

    protected Vector2 destination;
    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        destination = transform.position;

        Selected(false);
    }

    public void Selected(bool value)
    {
        isSelected = value;
    }

    private void OnMouseDown()
    {
        clickingOnSelf = true;
    }

    private void OnMouseUp()
    {
        clickingOnSelf = false;
    }

    protected virtual void Update()
    {
        //left click: move to the click location
        if (Input.GetMouseButtonDown(0) && isSelected && !clickingOnSelf)
        {
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        //change code for effect after gaining orb 
        //right click to attack
        //if (Input.GetMouseButtonDown(1) && isSelected)
        //{
            //Attack();
        //}
    }
}
