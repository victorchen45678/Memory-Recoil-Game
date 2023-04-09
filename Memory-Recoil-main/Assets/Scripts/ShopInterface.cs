using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopInterface : MonoBehaviour
{

    bool InteractableShop;
    public GameObject ShopManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    

    public void OpenShop()
    {
        ShopManager.SetActive(true);
    }

    public void CloseShop()
    {
        ShopManager.SetActive(false);
    }


    
}
