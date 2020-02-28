using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    private float t = 1;
    private float spawn_rate = 0.5f;
    public GameObject enemy1;
    public GameObject spawn_wall;
    private Transform spawn_point;
    Vector3 spawn_offset;
    float spawn_width;

    // Start is called before the first frame update
    void Start()
    {
        spawn_point = spawn_wall.GetComponent<Transform>();
        spawn_width = spawn_wall.GetComponent<Renderer>().bounds.size.x - 0.5f;
        spawn_offset.x = 0f;
        spawn_offset.y = 0f;
        spawn_offset.z = 0f;
        Debug.Log(spawn_wall.GetComponent<Renderer>().bounds.size.x + ", " + spawn_wall.GetComponent<Renderer>().bounds.size.y + ", " + spawn_wall.GetComponent<Renderer>().bounds.size.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (t <= 0)
        {
            spawn_e1();
            t = 1;
        } 
        else
        {
            t -= Time.deltaTime * spawn_rate;       
        }
   
    }

    void spawn_e1()
    {
        spawn_offset.x = Random.Range(-0.5f, 0.5f) * spawn_width;
        Instantiate(enemy1, spawn_point.position + spawn_offset, spawn_point.rotation);
    }
}
