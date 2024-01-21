using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] TMP_Text totalEggsCount,HighScore,LevelText;
    [SerializeField] GameObject StartCanvas,ScoreCanvas,GameManager,Bird;
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] LevelHandler level;
    [SerializeField] GameObject LevelCanvas,ShopCanvas;
    [SerializeField] Slider BackgroundSlider, SFXSlider;
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
        //Sounds

        BackgroundSlider.maxValue = 1;
        BackgroundSlider.minValue = 0;
        BackgroundSlider.value = SoundManager.instance._backgroundAudio.volume;


        SFXSlider.maxValue=1;
        SFXSlider.minValue = 0;
        SFXSlider.value = SoundManager.instance._SFXaudio.volume;
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

    public void RedidirectToPlaystore()
    {
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.GameXStudio.SquidGuysFallBeanEdition&hl=en&gl=US");
    }


    public void ChangeBackgroundMusicVolume()
    {
        SoundManager.instance._backgroundAudio.volume = BackgroundSlider.value;
        //ChangeBackgroundMusicVolume audio while replaying the game
        //PlayerPrefs.SetFloat("BgMusic", BackgroundSlider.value);
    }

    public void ChangeSFXMusicVolume()
    {
        SoundManager.instance._SFXaudio.volume = SFXSlider.value;
    }

    public void ShowTotalEggs()
    {
        totalEggsCount.text = PlayerPrefs.GetInt("TotalEggs").ToString();
    }

    public void ShowRewardedAds()
    {
        AdsInit.instance.GetComponent<RewardedAds>().ShowAd();
    }
}
