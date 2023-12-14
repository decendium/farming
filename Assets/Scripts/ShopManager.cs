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

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        inCircle = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        inCircle = false;
    }
}
