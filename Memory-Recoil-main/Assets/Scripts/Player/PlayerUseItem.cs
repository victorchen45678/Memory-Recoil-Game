using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUseItem : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject playerManager;
    public bool closeToDoor;
    public Animator animatorDoor;
    public Animator animatorDoorOther;

    //public Animator animatorRight;
    public GameObject powerupHealth;
    public GameObject powerupSpeed;
    public GameObject powerupInv;
    public Renderer PlayerRend;
    Color playerC;

    [SerializeField] private AudioSource potionSound;
    [SerializeField] AudioClip healthSound, shieldSound, speedSound, invinSound ;

    void Start()
    {
        
        PlayerRend = GetComponent<Renderer>();
        
        playerC = PlayerRend.material.color;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Item checkItem = InventorySystem.instance.UseSelectedIem(false);

            if(checkItem != null)
            {
                Debug.Log(checkItem.name);
                if (checkItem.name == "Key" && closeToDoor)
                {
                    Debug.Log(animatorDoor);
                    animatorDoor.SetFloat("key", 1);
                    animatorDoorOther.SetFloat("key", 1);

                    InventorySystem.instance.UseSelectedIem(true);
                }
                else if (checkItem.type == ItemType.Powerup)
                {
                    Debug.Log("Success!!!");
                    StartCoroutine(Powerup(checkItem));
                }
                
                
            }
        }
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Door"))
        {
            //Debug.Log("Interacting with Door !!!!!");
            closeToDoor = true;
            animatorDoor = collision.gameObject.GetComponent<Animator>();
            animatorDoorOther = collision.gameObject.GetComponent<DoorInteract>().animatorother;
        }
    }

    public void CallInvincible()
    {
        StartCoroutine(Invincable(1.5f));
    }


    IEnumerator Powerup(Item itemUse)
    {
        Debug.Log("test");


        if (itemUse.name == "Speed Potion")
        {
            playerManager.GetComponent<PlayerMovement>().UpdateSpeed(2);
            Instantiate(powerupSpeed, transform);
            InventorySystem.instance.UseSelectedIem(true);
            potionSound.clip = speedSound;
        }
        else if (itemUse.name == "Potion")
        {
            bool heal = playerManager.GetComponent<PlayerHealth>().CheckHealth();
            if (heal)
            {
                playerManager.GetComponent<PlayerHealth>().GainHealth(4);
                Instantiate(powerupHealth, transform);
                InventorySystem.instance.UseSelectedIem(true);
                potionSound.clip = healthSound;
            }
            
        }
        else if (itemUse.name == "Shield")
        {
            bool shield = playerManager.GetComponent<PlayerHealth>().CheckShield();
            if (shield)
            {
                playerManager.GetComponent<PlayerHealth>().GainShield(1);
                Instantiate(powerupHealth, transform);
                InventorySystem.instance.UseSelectedIem(true);
                potionSound.clip = shieldSound;
            }

        }
        else if (itemUse.name == "Invin")
        {
            StartCoroutine(Invincable(10f));
            Instantiate(powerupInv, transform);
            InventorySystem.instance.UseSelectedIem(true);
            potionSound.clip = invinSound;

        }
        potionSound.Play();

        yield return new WaitForSeconds(10f);


        if (itemUse.name == "Speed Potion")
        {
            playerManager.GetComponent<PlayerMovement>().UpdateSpeed(-2);
            
        }
        

    }


    IEnumerator Invincable(float period)
    {
        Physics2D.IgnoreLayerCollision(8, 9, true);
        playerC.a = 0.5f;
        PlayerRend.material.color = playerC;
        yield return new WaitForSeconds(period);
        Physics2D.IgnoreLayerCollision(8, 9, false);
        playerC.a = 1f;
        PlayerRend.material.color = playerC;
    }


}
