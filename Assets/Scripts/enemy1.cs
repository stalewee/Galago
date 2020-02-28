using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1 : MonoBehaviour
{
    public Rigidbody2D rb;
    public int health = 100;
    public float speed = 2;
    private float t = 1;
    private float fire_rate = 1;
    public GameObject bulletPrefab;
    public Transform fpr;
    public Transform fpl;
    private int crash_damage = 50;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.up * -speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }

        if (rb.position.y < -10)
        {
            Destroy(gameObject);
        }

        if (t <= 0f)
        {
            Shoot();
            t = 1f;
        }
        else
        {
            t -= Time.deltaTime * fire_rate;
        }

    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, fpr.position, fpr.rotation);
        Instantiate(bulletPrefab, fpl.position, fpl.rotation);
    }

     void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.name == "bottom_wall")
        {
            Destroy(gameObject);
        }
        else if (hitInfo.tag == "player")
        {
            player_status p = hitInfo.GetComponent<player_status>();
            if (p != null)
            {
                p.TakeDamage(crash_damage);
                Destroy(gameObject);
            }
        }
    }
}
