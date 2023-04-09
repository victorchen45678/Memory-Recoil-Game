using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLoot : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject lootPrefab;
    public List<Item> enemyDrops= new List<Item>();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    List<Item> GetLoot()
    {
        int randomChance = Random.Range(1, 101);
        List<Item> possibleLoot = new List<Item>();
        foreach (Item Loot in enemyDrops)
        {
            if(randomChance <= Loot.DropPercent)
            {
                possibleLoot.Add(Loot);
            }
        }
        if(possibleLoot.Count > 0)
        {
            return possibleLoot;
        }
        return null;
    }

    public void SpawnLoot(Vector3 location)
    {
        List<Item> itemsChosen = GetLoot();

        if(itemsChosen != null)
        {
            for(int i=0; i< itemsChosen.Count; i++)
            {
                GameObject lootGO = Instantiate(lootPrefab, location, Quaternion.identity);
                lootGO.GetComponent<SpriteRenderer>().sprite = itemsChosen[i].image;

                //float itemDropEffect = 300f;
                //Vector2 itemDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
                //lootGO.GetComponent<Rigidbody2D>().AddForce(itemDirection * itemDropEffect, ForceMode2D.Impulse);
            }

        }

    }
}
