using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryHandler : MonoBehaviour
{
    public GameManager gameManager;
    public TextMeshProUGUI amountText;
    public int cropType;

    // Initializes the inventory.
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        amountText.text = gameManager.inventory["c" + cropType].ToString();
    }

    // Updates the inventory every frame.
    void Update()
    {
        amountText.text = gameManager.inventory["c" + cropType].ToString();
    }
}
