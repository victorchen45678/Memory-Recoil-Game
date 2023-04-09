using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] public int maxHealth;
    [SerializeField] public int maxShield;

    public int currHealth;

    public int currShield;

    private float regenRate;
    private float lastRegen;
    private int regenAmt;

    // Start is called before the first frame update
    void Start()
    {
        currHealth = maxHealth;
        currShield = maxShield;
        regenRate = 2f;
        lastRegen = 0f;
        regenAmt = 1;
    }

    public void TakeDamage(int damage)
    {
        if (currShield > 0)
        {
            currShield--;
        }
        else
        {
            currHealth -= damage;
        }
    }

    public void GainHealth(int amount)
    {
        if (currHealth < maxHealth)
        {
            currHealth += amount;
        }
    }

    public void GainShield(int amount)
    {
        if (currShield < maxShield)
        {
            currShield += amount;
        }
    }

    public bool CheckHealth()
    {
        if(currHealth >= maxHealth)
        {
            return false;
        }

        return true;
    }

    public bool CheckShield()
    {
        if (currShield >= maxShield)
        {
            return false;
        }

        return true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        // If we implement picking up shield items from the ground, this will destroy it and increase player's shield by 1.
        // Just need to tag the item as "Shield"
        if (collision.CompareTag("Shield") && currShield < maxShield)
        {
            Destroy(collision.gameObject);
            GainShield(1);
        }

        if (collision.CompareTag("Regen") && currHealth < maxHealth)
        {
            if (Time.time > lastRegen + regenRate)
            {
                lastRegen = Time.time;
                GainHealth(regenAmt);
            }
        }

    }

}
