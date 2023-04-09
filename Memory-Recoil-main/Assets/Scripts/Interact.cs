using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interact : MonoBehaviour
{
    public bool inRange;
    public bool open;
    public KeyCode useKey;
    public UnityEvent action;
    public UnityEvent actionClose;

    public GameObject playerManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange)
        {
            if (Input.GetKeyDown(useKey) && open == false)
            {
                action.Invoke();
                open = true;
            }else if(Input.GetKeyDown(useKey) && open == true)
            {
                actionClose.Invoke();
                open = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inRange = true;
            playerManager.GetComponent<PlayerMovement>().NotifyPlayer();
        }
    }




    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inRange = false;
            playerManager.GetComponent<PlayerMovement>().DeNotifyPlayer();
        }
    }
}
