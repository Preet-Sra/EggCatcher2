using System.Collections;
using TMPro;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] TMP_Text totalEggsCount,HighScore,LevelText;
    [SerializeField] GameObject StartCanvas,ScoreCanvas,GameManager,Bird;
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] LevelHandler level;
    [SerializeField] GameObject LevelCanvas,ShopCanvas;
    private void Awake()
    {
        
        if (PlayerPrefs.GetInt("CurrentLevelIndex") > level.LevelDeatils.Length-1)
        {
            PlayerPrefs.SetInt("CurrentLevelIndex", level.LevelDeatils.Length - 1);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        totalEggsCount.text = PlayerPrefs.GetInt("TotalEggs").ToString();
        HighScore.text = "High Score: " + PlayerPrefs.GetInt("HighScore");
        
        LevelText.text = "Level " + level.LevelDeatils[PlayerPrefs.GetInt("CurrentLevelIndex")].LevelNumber;
    }

   public void StartGame()
    {
        
        Bird.SetActive(true);
        playerMovement.enabled = true;
        
        StartCanvas.SetActive(false);
        ScoreCanvas.SetActive(true);
        GameManager.SetActive(true);
    }

    public void OpenLevelCanvas()
    {
        LevelCanvas.SetActive(true);
    }
    public void OpenShop()
    {
        ShopCanvas.SetActive(true);
    }
}
