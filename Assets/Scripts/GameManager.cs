using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject pauseScreen;
    public GameObject cropSelectionScreen;
    public TextMeshProUGUI balanceText;
    public int balance;
    public Dictionary<string, int> inventory;
    // be like "type1", 1; "type2", 1; etc.
    // string is type of crop, second is amount that user has 

    private bool isPaused = false;
    private Crop selectedCrop;

    // Start is called before the first frame update
    void Start()
    {
        // load values from save if im not lazy 
        balance = 10;
        inventory = new Dictionary<string, int>()
        {
            {"crop1", 0 },
            {"crop2", 0 },
            {"crop3", 0 },
            {"crop4", 0 },
        };
    }

    // Update is called once per frame
    void Update()
    {
        CheckForPause();
        balanceText.text = "balance: $" + balance;
    }

    // Toggles the pause screen.
    void TogglePauseScreen()
    {
        if (pauseScreen.activeSelf == true)
        {
            pauseScreen.gameObject.SetActive(false);
            SetTimeScale(1);
            isPaused = false;
        } else
        {
            pauseScreen.gameObject.SetActive(true);
            SetTimeScale(0);
            isPaused = true;
        }
    }

    public void ToggleSelectionScreen()
    {
        if (cropSelectionScreen.activeSelf == true)
        {
            cropSelectionScreen.gameObject.SetActive(false);
        } else
        {
            cropSelectionScreen.gameObject.SetActive(true);
        }
    }

    // Resumes the game. (for the resume button in pause)
    public void ResumeGame()
    {
        pauseScreen.gameObject.SetActive(false);
        SetTimeScale(1);
        isPaused = false;
    }

    // Quits the game.
    public void QuitGame()
    {
        Debug.Log("Quitting game!");
        Application.Quit();
    }


    // Sets the time scale.
    // Usually 0 or 1 to pause/resume game
    void SetTimeScale(float timeScale)
    {
        Time.timeScale = timeScale;
    }

    // Checking to see if player pressed escape to pause the game.
    void CheckForPause()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isPaused == false)
        {
            TogglePauseScreen();
        } else if (Input.GetKeyDown(KeyCode.Escape) && isPaused == true)
        {
            TogglePauseScreen();
        }
    }

    // Sets the selected crops crop type.
    public void SetSelectedCropType(int cropType)
    {
        if (selectedCrop != null)
        {
            selectedCrop.SelectCrop(cropType);
            selectedCrop = null;
            ToggleSelectionScreen();
        }
    }

    // Assigns the crop.
    public void AssignSelectedCrop(Crop crop)
    {
        selectedCrop = crop;
    }

    // Changes the balance
    public void ChangeBalance(int price)
    {
        balance += price;
    }

    // Changes the value of a key in the inventory dictionary
    public void ChangeInventory(string key, int value)
    {
        inventory[key] += value;
    }
}
