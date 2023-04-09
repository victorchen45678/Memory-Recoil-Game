using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CurrencyManager : MonoBehaviour
{
    public int currencyCount;
    public TMP_Text currency_display_Main;
    public ShopManager shopTracker;
    //public TMP_Text currency_display_Shop;
    // Start is called before the first frame update
    void Start()
    {
        currency_display_Main.text = "Score: " + currencyCount.ToString();
        //currency_display_Shop.text = "Score: " + currencyCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCurrency()
    {
        currencyCount++;
        currency_display_Main.text = "Score: " + currencyCount.ToString();
        shopTracker.CheckCost();
        //currency_display_Shop.text = "Score: " + currencyCount.ToString();
        
    }

    public void SubtractCurrency(int spent)
    {
        currencyCount -= spent;
        currency_display_Main.text = "Score: " + currencyCount.ToString();
        shopTracker.CheckCost();
        //currency_display_Shop.text = "Score: " + currencyCount.ToString();
    }
}
