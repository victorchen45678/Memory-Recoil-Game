using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Scriptable object/Item")]

public class Item : ScriptableObject
{

    public TileBase tile;
    public Sprite image;
    public ItemType type;
    public ActionType action;
    public Vector2Int range = new Vector2Int(5, 4);
    public bool stackable = true;
    public int DropPercent;

    public string itemTitle;
    public string itemDescription;
    public int itemCost;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Drop(string itemTitle, int DropPercent)
    {
        this.itemTitle = itemTitle;
        this.DropPercent = DropPercent;
    }
}

public enum ItemType
{
    Tool,
    Weapon,
    Powerup
}
public enum ActionType
{
    Unlock,
    Shoot
}
