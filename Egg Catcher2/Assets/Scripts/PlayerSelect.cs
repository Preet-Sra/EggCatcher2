using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelect : MonoBehaviour
{
    public GameObject[] AllPlayers;

    private void Start()
    {
        ChangePlayerVisual();
    }

    public void ChangePlayerVisual()
    {
        for (int i = 0; i < AllPlayers.Length; i++)
        {
            AllPlayers[i].SetActive(false);
        }
        AllPlayers[PlayerPrefs.GetInt("SelectedCharacterIndex")].SetActive(true);
    }
}
