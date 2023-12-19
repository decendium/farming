using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject pauseScreen;
    public GameObject cropSelectionScreen;
    public GameObject inventoryScreen;
    public GameObject shopScreen;
    public GameObject storeRing;
    public GameObject playerObject;
    public TextMeshProUGUI balanceText;
    public int balance;
    public Dictionary<string, int> inventory;
    // be like "type1", 1; "type2", 1; etc.
    // string is type of crop, second is amount that user has 

    private bool isPaused = false;
    private bool isInInventory = false;
    private Crop selectedCrop;

    // Start is called before the first frame update
    void Start()
    {
        // load values from save if im not lazy 
        balance = 1000;
        inventory = new Dictionary<string, int>()
        {
            {"c1", 0 },
            {"c2", 0 },
            {"c3", 0 },
            {"c4", 0 },
        };
    }

    // Update is called once per frame
    void Update()
    {
        CheckForInput();
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

    // Toggles the selection screen.
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

    // Toggles the shop screen.
    public void ToggleShopScreen()
    {
        if (shopScreen.activeSelf == true)
        {
            shopScreen.gameObject.SetActive(false);
        }
        else
        {
            shopScreen.gameObject.SetActive(true);
        }
    }

    // Toggles the inventory screen.
    public void ToggleInventoryScreen()
    {
        if (inventoryScreen.activeSelf == true)
        {
            inventoryScreen.gameObject.SetActive(false);
            isInInventory = true;
        }
        else
        {
            inventoryScreen.gameObject.SetActive(true);
            isInInventory = false;
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

    // Returns true or false, if the player has the selection screen open.
    public bool IsSelecting()
    {
        return cropSelectionScreen.activeSelf;
    }

    // Sets the time scale.
    // Usually 0 or 1 to pause/resume game
    void SetTimeScale(float timeScale)
    {
        Time.timeScale = timeScale;
    }

    // Checking to see if player presses any buttons
    void CheckForInput()
    {
        // Checks for player pressing esc to open pause
        if (Input.GetKeyDown(KeyCode.Escape) && isPaused == false)
        {
            TogglePauseScreen();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused == true)
        {
            TogglePauseScreen();
        }

        // Checks for player pressing I to open inv
        if (Input.GetKeyDown(KeyCode.I) && isInInventory == false)
        {
            ToggleInventoryScreen();
        } 
        else if (Input.GetKeyDown(KeyCode.I) && isInInventory && true)
        {
            ToggleInventoryScreen();
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
