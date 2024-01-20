using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    Button button;
    public int LevelNumber;
    Menu menu;
    // Start is called before the first frame update
    void Start()
    {
        menu = FindObjectOfType<Menu>();
        button = GetComponent<Button>();
        button.onClick.AddListener(SelectLevel);
       
    }

   void SelectLevel()
    {
        PlayerPrefs.SetInt("CurrentLevelIndex", LevelNumber-1);

        //start the game
        menu.StartGame();
        //disable levelSelect
        transform.root.gameObject.SetActive(false);
    }
}
