using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Networking.PlayerConnection;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyDamage : MonoBehaviour
{
    public PlayerHealth playerHp;
    public Renderer PlayerRend;
    public PlayerUseItem playerInvin;

    // Change this value for the different types of enemies in the script attached to the prefab
    public int dmg;
    //private int bossDmg;
    float dmgInterval = 3f;
    float dmgTime;
    Color playerC;
    private Enemy enemyHp;

    //float shieldInterval = 2f;
    //float shieldTime;

    // Start is called before the first frame update
    void Start()
    {
        playerHp = GameObject.Find("Player").GetComponent<PlayerHealth>();
        PlayerRend = GameObject.Find("Player").GetComponent<Renderer>();
        playerInvin = GameObject.Find("Player").GetComponent<PlayerUseItem>();
        dmgTime = 0;
        playerC = PlayerRend.material.color;
        //shieldTime = 0;
        //bossDmg = 4;
        enemyHp = GetComponent<Enemy>();

        if (this.name == "EnemyAITank (Boss)")
        {
            dmg = 4;
        }
        Physics2D.IgnoreLayerCollision(8, 9, false);

    }

    // Update is called once per frame
    void Update()
    {
        if (this.name == "EnemyAITank (Boss)")
        {
            if (enemyHp.health < 67 && enemyHp.health > 33)
            {
                //Debug.Log("STAGE 2");
                dmg = 5;
            }
            else if (enemyHp.health <= 33)
            {
                //Debug.Log("STAGE 3");
                dmg = 6;
            }
        }
        if (playerHp.currHealth <= 0)
        {
            //playerHp.currHealth = playerHp.maxHealth;
            SceneManager.LoadScene(2);
        }
        //Debug.Log(playerHp.currHealth);
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") && dmgTime <= Time.time)
        {
            // If the player will die on hit
            if (playerHp.currHealth <= dmg && playerHp.currHealth > 0)
            {
                playerHp.TakeDamage(playerHp.currHealth);
                //Physics2D.IgnoreLayerCollision(8, 9, false);
                SceneManager.LoadScene(2);
                //Time.timeScale = 0;
            }
            // If the player won't die on hit
            else
            {
                // Check for shield first, otherwise remove health
                if (playerHp.currShield > 0)
                {
                    if (playerHp.currHealth > dmg)
                    {
                        playerHp.TakeDamage(1);
                        playerInvin.CallInvincible();
                    }
                    
                }
                else
                {
                    //if (this.name == "EnemyAITank (Boss)")
                    //{
                    //    //Debug.Log("YOOOOOOOOOO BOSS");
                    //    playerHp.TakeDamage(dmg);
                    //    StartCoroutine(Invincable(1.5f));
                    //}
                    //else
                    //{
                    if (playerHp.currHealth > dmg)
                    {
                        playerHp.TakeDamage(dmg);
                        playerInvin.CallInvincible();
                    }
                    
                    //}
                }
                dmgTime = Time.time + dmgInterval;
            }
        }

    }


    IEnumerator Invincable(float period)
    {
        Physics2D.IgnoreLayerCollision(8, 9, true);
        playerC.a = 0.5f;
        PlayerRend.material.color = playerC;
        Debug.Log("Invincible period");
        yield return new WaitForSeconds(period);
        Physics2D.IgnoreLayerCollision(8, 9, false);
        Debug.Log("INVINCIBILITY OFF");
        playerC.a = 1f;
        PlayerRend.material.color = playerC;
    }

}
