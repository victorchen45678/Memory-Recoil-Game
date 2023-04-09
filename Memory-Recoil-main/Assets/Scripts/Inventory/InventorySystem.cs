using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public static InventorySystem instance;


    public InventoryPosition[] allInventoryPositions;
    public GameObject ItemPrefab;
    public int maxItemAllowed = 10;

    int selectedPosition = 0;

    public void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        selectedPosition = 0;
        SelectSlot(0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectSlot(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectSlot(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SelectSlot(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SelectSlot(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SelectSlot(4);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            SelectSlot(5);
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            SelectSlot(6);
        }
    }
    void SelectSlot(int newPosition)
    {
        if (selectedPosition >= 0)
        {
            allInventoryPositions[selectedPosition].DeselectItem();
        }
        
        allInventoryPositions[newPosition].SelectItem();
        selectedPosition = newPosition;
    }

    public bool AddItem(Item item)
    {

        for (int i = 0; i < allInventoryPositions.Length; i++)
        {
            //Get Slot at current position
            //Debug.Log("Hi");
            InventoryPosition slot = allInventoryPositions[i];
            //Get children in slot which may or may not be an item
            InventoryObject objectInSlot = slot.GetComponentInChildren<InventoryObject>();
            //If found empty spot in inventory is found then place it
            if (objectInSlot != null && objectInSlot.item == item && objectInSlot.itemCount < maxItemAllowed && objectInSlot.item.stackable == true)
            {
                objectInSlot.itemCount++;
                objectInSlot.UpdateItemCount();
                PlaceNewItem(item, slot);
                return true;
            }
        }

        for (int i=0; i < allInventoryPositions.Length; i++)
        {
            //Get Slot at current position
            InventoryPosition slot = allInventoryPositions[i];
            //Get children in slot which may or may not be an item
            InventoryObject objectInSlot = slot.GetComponentInChildren<InventoryObject>();
            //If found empty spot in inventory is found then place it
            if(objectInSlot == null)
            {
                PlaceNewItem(item, slot);
                return true;
            }
        }
        Debug.Log("HEHE");
        return false;
    }

    void PlaceNewItem(Item item, InventoryPosition slot)
    {
        GameObject createdItem = Instantiate(ItemPrefab, slot.transform);

        InventoryObject inventoryObj = createdItem.GetComponent<InventoryObject>();
        inventoryObj.CreateItem(item);
    }

    public Item ChooseSelectedIem()
    {
        InventoryPosition slot = allInventoryPositions[selectedPosition];
        InventoryObject objectInSlot = slot.GetComponentInChildren<InventoryObject>();
        //If found empty spot in inventory is found then place it
        if (objectInSlot != null){
            return objectInSlot.item;
        }

        return null;
    }

    public Item UseSelectedIem(bool use)
    {
        InventoryPosition slot = allInventoryPositions[selectedPosition];
        InventoryObject objectInSlot = slot.GetComponentInChildren<InventoryObject>();
        //If found empty spot in inventory is found then place it
        if (objectInSlot != null)
        {
            Item item = objectInSlot.item;
            if (use && item.type != ItemType.Weapon)
            {
                objectInSlot.itemCount--;
                if(objectInSlot.itemCount <= 0)
                {
                    Destroy(objectInSlot.gameObject);
                }
                else
                {
                    objectInSlot.UpdateItemCount();
                }
            }
            return item;
        }

        return null;
    }
}
