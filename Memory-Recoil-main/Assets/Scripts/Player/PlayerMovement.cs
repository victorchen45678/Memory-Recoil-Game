using System;
using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb;



    public Camera GameCamera;


    [SerializeField] private float moveSpeed;
    [SerializeField] private AudioSource walkSound;
    [SerializeField] private AudioSource coinSound;

    Vector2 InputMovement;
    Vector2 AimDirection;

    public CurrencyManager currencyControl;

    public GameObject interactNotification;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        InputMovement.x = Input.GetAxisRaw("Horizontal");
        InputMovement.y = Input.GetAxisRaw("Vertical");
        if(InputMovement.x != 0 || InputMovement.y != 0)
        {
            if (!walkSound.isPlaying)
            {
                walkSound.Play();
            }
            
        }
       
        AimDirection = GameCamera.ScreenToWorldPoint(Input.mousePosition);
        interactNotification.transform.localPosition = new Vector3(transform.position.x, transform.position.y + 1, 0);



    }

    
    void FixedUpdate()
    {
        
        rb.MovePosition(rb.position + InputMovement * moveSpeed * Time.fixedDeltaTime);


        Vector2 LookingAt = AimDirection - rb.position;
        float turnAngle = Mathf.Atan2(LookingAt.y, LookingAt.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = turnAngle;
    }

    public void OnTriggerEnter2D(Collider2D collObj)
    {

        if (collObj.gameObject.CompareTag("Currency"))
        {
            Destroy(collObj.gameObject);
            currencyControl.AddCurrency();
            coinSound.Play();
        }

        if(collObj.gameObject.CompareTag("Escaped"))
        {
            SceneManager.LoadScene(3);
        }
    }

    public void UpdateSpeed(float upspeed)
    {
        moveSpeed += upspeed;
    }

    public void NotifyPlayer()
    {
        interactNotification.SetActive(true);
    }
    public void DeNotifyPlayer()
    {
        interactNotification.SetActive(false);
    }


}
