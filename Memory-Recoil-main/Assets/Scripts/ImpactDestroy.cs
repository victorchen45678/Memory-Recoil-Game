using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactDestroy : MonoBehaviour
{

    // Update is called once per frame
    public float destroyTime;
    void Update()
    {
        Destroy(gameObject, destroyTime);
    }
}
