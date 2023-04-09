using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryPosition : MonoBehaviour, IDropHandler
{
    public Image image;
    public Color activeColor, notActiveColor;

    private void Awake()
    {
        DeselectItem();
    }

    public void SelectItem()
    {
        image.color = activeColor;
    }

    public void DeselectItem()
    {
        image.color = notActiveColor;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            InventoryObject newInventoryItem = eventData.pointerDrag.GetComponent<InventoryObject>();
            newInventoryItem.itemAfterDrag = transform;
        }

    }
}
