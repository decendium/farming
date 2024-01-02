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

    public void ChangeInventoryAmount(int amountAndType)
    {
        int amount, cropType;
        // Ok man like idk anymore but umm 
        // the int will be croptype and then the amount so like 14 would be 4 of crop 1 
        // type is last digit so % 10
        cropType = amountAndType % 10;
        amount = (amountAndType - (amountAndType % 10)) / 10;
        
        gameManager.ChangeInventory("c" + cropType.ToString(), -amount);
    }

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

    public void ChangeBalance(int amount)
    {
        gameManager.ChangeBalance(amount);
    }
}
