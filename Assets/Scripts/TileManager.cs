using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileManager : MonoBehaviour
{
    public Owner CurrentPlayer;
    public Tile[] Tiles = new Tile[9];

    public GameObject quitButton;
    public GameObject resetButton;

    public int swordScore = 0;
    public int shieldScore = 0;
    public GameObject swordText;
    public GameObject shieldText;

    private int counter = 0;
    public bool GameEndedButNotReset = false;

    public enum Owner
    {
        None,
        Sword,
        Shield
    }

    public void OnResetClick()
    {
        resetButton.SetActive(false);
        quitButton.SetActive(false);
        for (int i = 0; i < 9; ++i)
        {
            Tiles[i].GetComponent<SpriteRenderer>().color = Color.white;
            Tiles[i].owner = Owner.None;
            Tiles[i].sword.SetActive(false);
            Tiles[i].shield.SetActive(false);
        }
        CurrentPlayer = Owner.Sword;
        counter = 0;
        GameEndedButNotReset = false;
    }

    public void OnQuitClick()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }

    public bool won;
    public bool tie;

    // Start is called before the first frame update
    void Start()
    {
        won = false;
        CurrentPlayer = Owner.Sword;
    }

    public void ChangePlayer()
    {
        ++counter;

        if (CheckForWinner())
            return;

        if (CurrentPlayer == Owner.Sword)
            CurrentPlayer = Owner.Shield;
        else
            CurrentPlayer = Owner.Sword;
        
    }

    public bool CheckForWinner()
    {
        if (Tiles[0].owner == CurrentPlayer && Tiles[1].owner == CurrentPlayer && Tiles[2].owner == CurrentPlayer)
            won = true;
        else if (Tiles[3].owner == CurrentPlayer && Tiles[4].owner == CurrentPlayer && Tiles[5].owner == CurrentPlayer)
            won = true;
        else if (Tiles[6].owner == CurrentPlayer && Tiles[7].owner == CurrentPlayer && Tiles[8].owner == CurrentPlayer)
            won = true;
        else if (Tiles[0].owner == CurrentPlayer && Tiles[3].owner == CurrentPlayer && Tiles[6].owner == CurrentPlayer)
            won = true;
        else if (Tiles[1].owner == CurrentPlayer && Tiles[4].owner == CurrentPlayer && Tiles[7].owner == CurrentPlayer)
            won = true;
        else if (Tiles[2].owner == CurrentPlayer && Tiles[5].owner == CurrentPlayer && Tiles[8].owner == CurrentPlayer)
            won = true;
        else if (Tiles[0].owner == CurrentPlayer && Tiles[4].owner == CurrentPlayer && Tiles[8].owner == CurrentPlayer)
            won = true;
        else if (Tiles[2].owner == CurrentPlayer && Tiles[4].owner == CurrentPlayer && Tiles[6].owner == CurrentPlayer)
            won = true;

        if (counter >= 9)
        {
            tie = true;
        }

        if ((won || tie))
        {
            if (won)
            {
                Debug.Log("Winner: " + CurrentPlayer);
                if (CurrentPlayer == Owner.Sword)
                {
                    ++swordScore;
                    swordText.GetComponent<Text>().text = "Swords: " + swordScore;
                }
                else
                {
                    ++shieldScore;
                    shieldText.GetComponent<Text>().text = "Shields: " + shieldScore;
                }
            }
            else if (tie)
                Debug.Log("It was a tie");

            resetButton.SetActive(true);
            quitButton.SetActive(true);
            CurrentPlayer = Owner.Sword;

            won = false;
            tie = false;
            GameEndedButNotReset = true;

            return true;
        }

        return false;
    }
}
