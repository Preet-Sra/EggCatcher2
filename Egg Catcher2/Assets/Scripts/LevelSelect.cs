using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    [SerializeField] Button[] AllLevels;
    [SerializeField] LevelHandler level;
    [SerializeField] ScrollRect scrollRect;
    [SerializeField] GameObject LevelSelectCanvas;
    private void OnEnable()
    {
        for(int i = 0; i < AllLevels.Length; i++)
        {
            AllLevels[i].interactable = false;
        }
        AllLevels[0].enabled = true;
        for(int i=0;i< level.LevelDeatils[PlayerPrefs.GetInt("CurrentLevelIndex")].LevelNumber; i++)
        {
            AllLevels[i].interactable = true;
        }
        ResetScrollView();
    }
    

    public void CloseLevelSelection()
    {
        LevelSelectCanvas.SetActive(false);
    }

   
    void ResetScrollView()
    {
        // Reset the scroll view to the top
        scrollRect.content.anchoredPosition = new Vector2(0, 116f);
    }
}
