using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleDetector : MonoBehaviour
{
    public ShopManager shopManager;

    // Start is called before the first frame update
    void Start()
    {
        shopManager = GameObject.Find("ShopManager").GetComponent<ShopManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            shopManager.inCircle = true;
            Debug.Log("In");
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            shopManager.inCircle = false;
            Debug.Log("Out");
        }
    }
}
