using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartWaveDetection : MonoBehaviour
{

    public event EventHandler PlayerEnterBattle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D colObj)
    {
        if (colObj.gameObject.CompareTag("Player"))
        {
            Debug.Log("entered");
            PlayerEnterBattle?.Invoke(this, EventArgs.Empty);
        }
    }
}
