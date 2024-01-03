using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject circle;
    public GameObject shopPopupScreen;
    public GameObject shopScreen;
    public bool inCircle;
    public bool isShowingPopup;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckForPopup();
        CheckForShop();
    }

    // Checks for the shop popup while you are in the circle, toggles screens accordingly.
    private void CheckForPopup()
    {
        if (inCircle == true && isShowingPopup == false)
        {
            shopPopupScreen.gameObject.SetActive(true);
            isShowingPopup = true;
        } 

        if (inCircle == false && isShowingPopup == true) 
        {
            shopPopupScreen.gameObject.SetActive(false);
            isShowingPopup = false;
        }

        if (shopScreen.activeSelf == true)
        {
            shopPopupScreen.gameObject.SetActive(false);
            isShowingPopup = false;
        }
    }

    // WHAT IS HAPPENING!!
    private void CheckForShop()
    {
        if (isShowingPopup == true && Input.GetKeyDown(KeyCode.P))
        {
            gameManager.ToggleShopScreen();
            gameManager.ToggleInventoryScreen();
            shopPopupScreen.gameObject.SetActive(false);
            isShowingPopup = false;
        } 
        else
        {
            // If the shop screen is active and either P or Esc is pressed, toggle the shop screen and show the popup again 
            if (shopScreen.activeSelf == true && (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))) {
                gameManager.ToggleShopScreen();
                gameManager.ToggleInventoryScreen();
                shopPopupScreen.gameObject.SetActive(true);
                isShowingPopup = true;
            }
        }
    }

    // Changes the inventory amount, given an amount and type.
    public void ChangeInventoryAmountAndBalance(int amountAndType)
    {
        int amount, cropType;
        cropType = amountAndType % 10;
        amount = (amountAndType - (amountAndType % 10)) / 10;
        gameManager.ChangeInventory("c" + cropType.ToString(), -amount);

    }

    // Changes the player's balance.
    public void ChangeBalance(int amount)
    {
        gameManager.ChangeBalance(amount);
    }
}
