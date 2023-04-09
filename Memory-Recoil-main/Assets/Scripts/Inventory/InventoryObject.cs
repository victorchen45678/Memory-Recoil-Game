using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using System;

public class InventoryObject : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public Item item;
    public TMP_Text numberText;

    [Header("UI")]
    public Image ImageSlot;
    [HideInInspector] public int itemCount = 1;
    [HideInInspector] public Transform itemAfterDrag;

    // Start is called before the first frame update
    
    
    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateItem(Item foundItem)
    {
        
        item = foundItem;
        ImageSlot.sprite = foundItem.image;
        UpdateItemCount();
    }

    public void UpdateItemCount()
    {
        numberText.text = itemCount.ToString();
        bool textOn = itemCount > 1;
        numberText.gameObject.SetActive(textOn);
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        ImageSlot.raycastTarget = false;
        itemAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        numberText.raycastTarget = false;

    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        ImageSlot.raycastTarget = true;
        transform.SetParent(itemAfterDrag);
        numberText.raycastTarget = true;
    }
}
