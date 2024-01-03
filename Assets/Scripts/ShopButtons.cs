using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButtons : MonoBehaviour
{
    public GameManager gameManager;
    public int cropType;
    public int amount;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        CheckPurchase();
    }

    // Update is called once per frame
    void Update()
    {
        CheckPurchase();
    }

    // This is so weird but it works!
    // Changes the inventory amount by a given number.
    public void ChangeInventoryAmount(int amountAndType)
    {
        int amount, cropType;
        cropType = amountAndType % 10;
        amount = (amountAndType - (amountAndType % 10)) / 10;
        
        gameManager.ChangeInventory("c" + cropType.ToString(), -amount);
    }

    // Checks to see if player has enough of crop to sell.
    public void CheckPurchase()
    {
        if (!(gameManager.inventory["c" + cropType.ToString()] >= amount))
        {
            GetComponent<Button>().interactable = false;
        } else
        {
            GetComponent<Button>().interactable = true;
        }
    }

    // Changes the player's balance.
    public void ChangeBalance(int amount)
    {
        gameManager.ChangeBalance(amount);
    }
}
