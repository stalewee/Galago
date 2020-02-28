using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e1_bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    private float speed = 4f;
    private int damage = 20;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.tag == "wall")
        {
            Destroy(gameObject);
        }
        else if (hitInfo.tag == "player")
        {
            player_status p = hitInfo.GetComponent<player_status>();
            if (p != null)
            {
                p.TakeDamage(damage);
                Destroy(gameObject);
            }
        }
    }
}
