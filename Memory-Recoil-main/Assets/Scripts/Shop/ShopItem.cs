using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="ShopMenu", menuName = "Scriptable object/Shop Item", order=1)]
public class ShopItem : ScriptableObject
{
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
}
