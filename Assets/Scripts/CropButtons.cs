using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CropButtons : MonoBehaviour
{
    public int cropCost;
    public GameManager gameManager;
    public GameObject noIcon;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        CheckAffordability();
    }

    // Update is called once per frame
    void Update()
    {
        CheckAffordability();
    }

    // Checks if a player can afford the crop they are planting. 
    public void CheckAffordability()
    {
        if (gameManager.balance < cropCost)
        {
            GetComponent<Button>().interactable = false;
            noIcon.SetActive(true);
        } 
        else
        {
            GetComponent<Button>().interactable = true;
            noIcon.SetActive(false);
        }
    }
}
