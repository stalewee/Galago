using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mgun_flash : MonoBehaviour
{
    public Transform firepoint = null;
    public Transform flashpoint;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (firepoint != null)
        {
            flashpoint.position = firepoint.position;
        }
    }

}
