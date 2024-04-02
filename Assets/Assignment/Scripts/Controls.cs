using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    //referenced from week 7 
    //the player can choose between the SpaceSquad consiting of four different prefabs
    public static SpaceSquad SelectedPlayer { get; private set; }

    public static void SetSelectedPlayer(SpaceSquad player, Transform playerTransform)
    {
        if (SelectedPlayer != null)
        {
            SelectedPlayer.Selected(false);
        }

        player.Selected(true);
        SelectedPlayer = player;

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePosition - playerTransform.position).normalized;
        player.rb.velocity = direction * player.Speed;
    }

    //player can control where the character moves by clicking
    //its better to click and hold where the characters will go when playing 
    private void Update()
    {
        if (SelectedPlayer == null) return;
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector2 direction = (mousePosition - SelectedPlayer.transform.position).normalized;
            SelectedPlayer.rb.velocity = direction * SelectedPlayer.Speed;
        }
        else
        {
            SelectedPlayer.rb.velocity = Vector2.zero;
        }
    }

}
