using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public TileManager tileManager;
    public TileManager.Owner owner;

    public GameObject sword;
    public GameObject shield;

    private void OnMouseUp()
    {
        if (!tileManager.GameEndedButNotReset)
        {
            // Check for current player that is claiming ownership of this space
            owner = tileManager.CurrentPlayer;

            // Set the sprite color to represent the owner (Sword = Blue, Shield = Red)
            if (owner == TileManager.Owner.Sword)
            {
                this.GetComponent<SpriteRenderer>().color = Color.blue;
                sword.SetActive(true);
            }
            else if (owner == TileManager.Owner.Shield)
            {
                this.GetComponent<SpriteRenderer>().color = Color.red;
                shield.SetActive(true);
            }

            // Update to the next player in rotation
            tileManager.ChangePlayer();
        }

        //// Check for current player that is claiming ownership of this space
        //owner = tileManager.CurrentPlayer;

        //// Set the sprite color to represent the owner (Sword = Blue, Shield = Red)
        //if (owner == TileManager.Owner.Sword)
        //{
        //    this.GetComponent<SpriteRenderer>().color = Color.blue;
        //    sword.SetActive(true);
        //}  
        //else if (owner == TileManager.Owner.Shield)
        //{
        //    this.GetComponent<SpriteRenderer>().color = Color.red;
        //    shield.SetActive(true);
        //}

        //// Update to the next player in rotation
        //tileManager.ChangePlayer();
    }
}
