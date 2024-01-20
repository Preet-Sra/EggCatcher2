using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using TMPro;


public class Shop : MonoBehaviour
{
    public Image characterImage;
    public Sprite[] AllCharacters;
    public int currentIndex;
    public int TotalCharacters;
    public Button NextButton, PreviousButton;
    bool[] isCharacterPurchased;
    public Button actionButton;
    public int[] CharacterPrices;
    public TMP_Text totalEggsCount;
    PlayerSelect player;
    public GameObject ShopCanvas;
   
    private void Start()
    {
        player = FindObjectOfType<PlayerSelect>();
        currentIndex = PlayerPrefs.GetInt("SelectedCharacterIndex");
        isCharacterPurchased = new bool[TotalCharacters];

        // Unlock the first character by default
        isCharacterPurchased[0] = true;

        // Load purchase status from PlayerPrefs
        for (int i = 1; i < TotalCharacters; i++)
        {
            isCharacterPurchased[i] = PlayerPrefs.GetInt("Character_" + i + "_Purchased", 0) == 1;
        }
        ShowCharacterImage();
        UpdateActionButtonText();

    }

    public void ShowNextCharacter()
    {
        currentIndex++;
      
        
        if (currentIndex >= TotalCharacters - 1)
        {
            NextButton.interactable = false;
            currentIndex = TotalCharacters - 1;
        }
        else
        {
            NextButton.interactable = true;
        }
        UpdateActionButtonText();
        PreviousButton.interactable = true;
        ShowCharacterImage();
    }

    public void ShowPreviousCharacter()
    {
        currentIndex--;
       
        
        if (currentIndex <= 0)
        {
            PreviousButton.interactable = false;
            currentIndex = 0;
        }
        else
        {
            PreviousButton.interactable = true;
           
        }
        NextButton.interactable = true;
        UpdateActionButtonText();
        ShowCharacterImage();
    }

    void ShowCharacterImage()
    {
        characterImage. sprite = AllCharacters[currentIndex];
        
    }

    void UpdateActionButtonText()
    {
        if (isCharacterPurchased[currentIndex])
        {
            actionButton.GetComponentInChildren<TMP_Text>().text = "Play";
        }
        else
        {
            actionButton.GetComponentInChildren<TMP_Text>().text = CharacterPrices[currentIndex] + " <sprite=0>";
        }
    }

    public void PerformAction()
    {
        if (isCharacterPurchased[currentIndex])
        {
            // Implement logic to start playing with the selected character
            Debug.Log("Play the game with the selected character.");
            PlayerPrefs.SetInt("SelectedCharacterIndex", currentIndex);
            player.ChangePlayerVisual();
            CloseShop();
        }
        else
        {
            
            int TotalEggs = PlayerPrefs.GetInt("TotalEggs");

            if (TotalEggs >= CharacterPrices[currentIndex])
            {
                TotalEggs -= CharacterPrices[currentIndex];
                PlayerPrefs.SetInt("TotalEggs", TotalEggs);

                // 1 is for unlock
                PlayerPrefs.SetInt("Character_" + currentIndex + "_Purchased", 1);
                isCharacterPurchased[currentIndex] = true;

                // Update the action button text after the purchase
                UpdateActionButtonText();
                totalEggsCount.text = ""+TotalEggs;
                
                PlayerPrefs.SetInt("SelectedCharacterIndex", currentIndex);
                player.ChangePlayerVisual();
                CloseShop();
            }
            else
            {
                Debug.Log("Not enough Eggs to purchase the character.");
                // Optionally, you can display a message to inform the player that they don't have enough coins.
            }
        }
    }

    void CloseShop()
    {
        ShopCanvas.SetActive(false);
    }
}
