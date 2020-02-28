using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mgun : MonoBehaviour
{
    public Transform fpr;
    public Transform fpl;
    public GameObject bulletPrefab;
    private float t = 1;
    private float fire_speed = 20;
    public GameObject mgun_flash;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            if (t <= 0)
            {
                shoot();
                t = 1;
            }
            else
            {
                t -= Time.deltaTime * fire_speed;
            }
        }
    }

    void shoot()
    {
        var flash_R = Instantiate(mgun_flash, fpr.position, fpr.rotation);
        var flash_L = Instantiate(mgun_flash, fpl.position, fpl.rotation);
        flash_R.GetComponent<mgun_flash>().firepoint = fpr;
        flash_L.GetComponent<mgun_flash>().firepoint = fpl;
        Instantiate(bulletPrefab, fpr.position, fpr.rotation);
        Instantiate(bulletPrefab, fpl.position, fpl.rotation);

    }
}
