using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    private bool canPickUp;
    [SerializeField] private SpriteRenderer spriteItem;
    [SerializeField] public Item item;

    // Start is called before the first frame update
    public void Start()
    {
        SetItemToObject(item);
        
        
    }

    public void SetItemToObject(Item itemStart)
    {
        this.item = itemStart;
        spriteItem.sprite = item.image;

    }

    // Update is called once per frame
    void Update()
    {
        if (canPickUp && Input.GetKeyDown(KeyCode.E))
        {
            PickedUp();
        }
    }

    private void PickedUp()
    {
        bool openSpace = InventorySystem.instance.AddItem(item);
        if (openSpace)
        {
            Destroy(gameObject);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canPickUp = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canPickUp = false;
        }
    }

}
