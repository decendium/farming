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
        CheckForInCircle();
    }

    private void CheckForInCircle()
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
    }
}
