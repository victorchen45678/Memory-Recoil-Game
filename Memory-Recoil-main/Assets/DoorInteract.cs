using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteract : MonoBehaviour
{
    public Animator animatorother;

    void DoorDisapear()
    {
        
        gameObject.SetActive(false);
        AstarPath.active.Scan();

    }
}
