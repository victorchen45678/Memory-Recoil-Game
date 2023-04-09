using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{

    public int currency;
    public TMP_Text currency_display;
    public Item[] shopItemArray;
    public GameObject[] shopItemPanelsObject;
    public ShopCanvas[] shopItemPanels;
    public Button[] itemPanelButtons;
    public CurrencyManager currencyControl;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < shopItemArray.Length; i++)
        {
            shopItemPanelsObject[i].SetActive(true);
        }
        //currency_display.text = "Score: " + currency.ToString();
        //currency = currencyControl.currencyCount;
        LoadShopItems();
        CheckCost();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public void AddCurrency()
    //{
    //    currency++;
    //    currency_display.text = "Score: " + currency.ToString();
    //    CheckCost();
    //}

    public void LoadShopItems()
    {
        for(int i=0; i< shopItemArray.Length; i++)
        {
            shopItemPanels[i].title.text = shopItemArray[i].itemTitle;
            shopItemPanels[i].descriptionText.text = shopItemArray[i].itemDescription;
            shopItemPanels[i].costText.text = "Score: " + shopItemArray[i].itemCost.ToString();
            shopItemPanels[i].itemImage.sprite = shopItemArray[i].image;

        }
    }

    public void CheckCost()
    {
        for (int i = 0; i < shopItemArray.Length; i++)
        {
            if (currencyControl.currencyCount >= shopItemArray[i].itemCost)
            {
                itemPanelButtons[i].interactable = true;
            }
            else
            {
                itemPanelButtons[i].interactable = false;
            }

        }
    }

    public void BuyItem(int slotNumber)
    {
        if(currencyControl.currencyCount >= shopItemArray[slotNumber].itemCost)
        {
            bool openSpace = InventorySystem.instance.AddItem(shopItemArray[slotNumber]);
            currencyControl.SubtractCurrency(shopItemArray[slotNumber].itemCost);
            CheckCost();
        }
    }
}
