using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteraction : MonoBehaviour
{
    public float amp;
    public float freq;
    public Vector3 inital;
    // Start is called before the first frame update
    void Start()
    {
        inital = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(inital.x, Mathf.Sin(Time.time * freq) * amp + inital.y, 0);
    }
}
