using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryHandler : MonoBehaviour
{
    public GameManager gameManager;
    public TextMeshProUGUI amountText;
    public int cropType;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        amountText.text = gameManager.inventory["c" + cropType].ToString();
    }

    // Update is called once per frame
    void Update()
    {
        amountText.text = gameManager.inventory["c" + cropType].ToString();
    }
}
