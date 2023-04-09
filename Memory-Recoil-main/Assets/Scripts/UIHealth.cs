using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealth : MonoBehaviour
{
    private PlayerHealth playerHp;

    public int currHp;
    public int maxHp;

    // Sprites 0-9, with 0 being empty and 9 being full.
    [SerializeField] private Sprite[] healthBars;

    // Start is called before the first frame update
    void Start()
    {
        playerHp = GameObject.Find("Player").GetComponent<PlayerHealth>();
        maxHp = playerHp.maxHealth;
        currHp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        currHp = playerHp.currHealth;
        // To fix indexing errors (which idt we have to) we need to know how much damage is incoming and check if that damage is
        // greather than or equal to currHp. If it is, we set curr to 0 and it indexes to the empty hp bar
        if (currHp <= 0)
        {
            //GetComponent<Image>().sprite = healthBars[0];
            playerHp.currHealth = 0;
        }
        else if (currHp > maxHp)
        {
            playerHp.currHealth = maxHp;
        }
        //else
        //{
        //Debug.Log(playerHp.currHealth);
        GetComponent<Image>().sprite = healthBars[playerHp.currHealth];
        //}
        //Debug.Log(currHp);
    }
}
