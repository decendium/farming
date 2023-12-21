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
    public void ChangeInventoryAmount(int amount, int cropType)
    {
        gameManager.ChangeInventory("c" + cropType.ToString(), -amount);
    }

    public void ChangeBalance(int amount)
    {
        gameManager.ChangeBalance(amount);
    }
}
