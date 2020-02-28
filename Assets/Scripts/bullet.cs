using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    private float speed = 20f;
    private int damage = 20;
    public ParticleSystem splode;
    
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
        else if (hitInfo.tag == "enemy")
        {
            enemy1 e1 = hitInfo.GetComponent<enemy1>();
            if (e1 != null)
            {
                e1.TakeDamage(damage);
                Instantiate(splode, rb.position, rb.transform.rotation);
                Destroy(gameObject);
            }
        }
    }
}
