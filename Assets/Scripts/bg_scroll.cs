using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bg_scroll : MonoBehaviour
{
    public GameObject top;
    public GameObject bottom;
    private float scroll_speed = 0.5f;
    private Vector3 top_pos;
    private Vector3 bottom_pos;
    private float flip_point = -12.96f;

    // Start is called before the first frame update
    void Start()
    {
        top_pos = top.transform.position;
        bottom_pos = bottom.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        top_pos.y -= Time.deltaTime * scroll_speed;
        bottom_pos.y -= Time.deltaTime * scroll_speed;
        if (top_pos.y < flip_point)
        {
            top_pos.y += 12.96f * 2f;
        }
        if (bottom_pos.y < flip_point)
        {
            bottom_pos.y += 12.96f * 2f;
        }
        top.transform.position = top_pos;
        bottom.transform.position = bottom_pos;
        
    }
}
