using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [SerializeField] TMP_Text scoreText,targetText;
    private int eggsCount, lifesRemaining = 3;
    PlayerMovement player;
    [SerializeField] Animator gameOverAnim;
    [SerializeField] Image[] heartImages;
    [SerializeField] LevelHandler levelHandler;
    int TargetCount;

    [Space(2)]
    [Header("Pause")]
    [SerializeField]Animator pauseAnim;
    [SerializeField] TMP_Text PauseLevelText;


    [Space(5)]
    [Header("GameOver")]
    [SerializeField] TMP_Text EggsCollectedText;
    [SerializeField] TMP_Text target, HighScore;

    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        Time.timeScale = 1;

    }

    private void Start()
    {
        eggsCount = 0;
        scoreText.text = eggsCount.ToString();
        lifesRemaining = 3;
        UpdateHeartImages();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        Debug.Log(PlayerPrefs.GetInt("CurrentLevelIndex"));
        TargetCount = levelHandler.LevelDeatils[PlayerPrefs.GetInt("CurrentLevelIndex")].TargetCount;
        targetText.text = "Target: " +TargetCount ;
        PauseLevelText.text = "Level: " + levelHandler.LevelDeatils[PlayerPrefs.GetInt("CurrentLevelIndex")].LevelNumber;
    }


    public void IncreaseScore()
    {
        eggsCount++;
        if (eggsCount >= PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", eggsCount);
        }
        scoreText.text = eggsCount.ToString();
        PlayerPrefs.SetInt("TotalEggs", PlayerPrefs.GetInt("TotalEggs") + 1);

        if (eggsCount >= TargetCount)
        {
            Time.timeScale = 0;
            PlayerPrefs.SetInt("CurrentLevelIndex", PlayerPrefs.GetInt("CurrentLevelIndex") + 1);
            Debug.Log("Won");
        }

    }

    

    public void ReduceLife()
    {
        
        lifesRemaining--;
        if (lifesRemaining <= 0)
        {
            lifesRemaining = 0;
            player.Dead();
            gameOverAnim.SetTrigger("GameOver");
            EggsCollectedText.text = "Egg Count: " + eggsCount;
            HighScore.text = "High Score: " + PlayerPrefs.GetInt("HighScore");
            target.text = "Target Count: " + GameManager.instance.target;
            
            Time.timeScale = 0;
            if(PlayerPrefs.GetInt("AdsRemoved")!=1)
                AdsInit.instance.GetComponent<InterstitialAds>().ShowAd();
        }


        UpdateHeartImages();
    }


    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Pause()
    {
        Time.timeScale = 0;
        pauseAnim.Play("Pause");
    }

    public void Resume()
    {
        pauseAnim.Play("Pause2");
        StartCoroutine(ResumeGame());
    }

    IEnumerator ResumeGame()
    {
        yield return new WaitForSecondsRealtime(0.3f);
        Time.timeScale = 1;
    }

    public void Exit()
    {
        Application.Quit();
    }

    void UpdateHeartImages()
    {
        for (int i = 0; i < heartImages.Length; i++)
        {
            if (i < lifesRemaining)
            {
                // Enable heart image if it corresponds to a remaining life
                heartImages[i].enabled = true;
            }
            else
            {
                // Disable heart image if it doesn't correspond to a remaining life
                heartImages[i].enabled = false;
            }
        }
    }
}