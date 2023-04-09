using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 10f;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float timeLive = 3.0f;
    [SerializeField] public float BulletDamage = 1f;

    public GameObject bloodimpact;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = bulletSpeed * transform.right;
    }
    void Update()
    {
        Destroy(gameObject, timeLive);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy>().LoseHealth(BulletDamage);
            Instantiate(bloodimpact, transform.position, Quaternion.identity);
        }
        if (!collision.CompareTag("WaveTrigger") && !collision.CompareTag("Regen") && !collision.CompareTag("Currency"))
        {
            //Debug.Log(collision.collider.gameObject.name);
            //Debug.Log(collision.collider.gameObject.tag);
            Destroy(gameObject);
        }
    }
}
