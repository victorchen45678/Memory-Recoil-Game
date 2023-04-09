using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class Enemy : MonoBehaviour
{




    /// <summary>
    /// Our rigid body component
    /// Used to apply forces so we can move around
    /// </summary>
    

    /// <summary>
    /// Vector from us to the player
    /// </summary>
    //private Vector2 OffsetToPlayer;

    /// <summary>
    /// Unit vector in the direction of the player, relative to us
    /// </summary>
    //private Vector2 HeadingToPlayer;

    //public Transform playerChase;
    //public float enemySpeed;
    //public float enemyDistance;
    //public float enemyStopDistance;

    //public float currentTime;
    //public float shootingSpeed;
    public float maxHealth;
    public float health;

    public EnemyHealth HealthBar;

    public GameObject enemyDestroy;
    public GameObject keyDrop;

    public AIPath pathfinder;

    [SerializeField] private AudioSource enemySound;


    void Start()
    {
        //playerChase = GameObject.FindGameObjectWithTag("Player").transform;
        //enemyStopDistance = 0f;
        //enemyDistance = 2f;


        //currentTime = Time.time;

        HealthBar.SetHealth(health, maxHealth);
        pathfinder = GetComponent<AIPath>();

    }

    // Update is called once per frame
    void Update()
    {
        if (this.name == "EnemyAITank (Boss)")
        {
            if (health < (.67f * maxHealth)  && (health > (.33f * maxHealth)))
            {
                pathfinder.maxSpeed = 2;
            }
            if (health <= (.33f * maxHealth))
            {
                pathfinder.maxSpeed = 4;
            }


        }
        float randomSound = Random.Range(0f, 101f);

        if (!enemySound.isPlaying && randomSound <= 0.3f)
        {
            enemySound.Play();
        }
    }

    public void Spawn()
    {
        gameObject.SetActive(true);
    }


    public void LoseHealth(float damage)
    {
        health -= damage;
        HealthBar.SetHealth(health, maxHealth);
        if (health <= 0)
        {
            GameObject destoryEffect = Instantiate(enemyDestroy, transform.position, transform.rotation);
            Destruct();
        }
    }




    void Destruct()
    {
        if (this.name == "EnemyAITank (Boss)")
        {

            Instantiate(keyDrop, transform.position, transform.rotation);

        }
        else
        {
            GetComponent<EnemyLoot>().SpawnLoot(transform.position);
        }
        
        Destroy(gameObject);
    }

}
