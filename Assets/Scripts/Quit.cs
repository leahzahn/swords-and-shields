using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    public GameObject quitButton;

    public void OnClick()
    {
        quitButton.SetActive(true);
    }
}
