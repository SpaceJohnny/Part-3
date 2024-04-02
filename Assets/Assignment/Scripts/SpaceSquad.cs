using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SpaceSquad : MonoBehaviour
{
    public float Speed = 20f;
    public SpriteRenderer sr;
    public Rigidbody2D rb;

    public Color selectedColour;
    public Color unselectedColour;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        Selected(false);
    }

    //referenced from week 7
    private void OnMouseDown()
    {
        Controls.SetSelectedPlayer(this, transform);
    }

    public void Selected(bool isSelected)
    {
        if (isSelected)
        {
            sr.color = selectedColour;
        }
        else
        {
            sr.color = unselectedColour;
        }
    }
}
