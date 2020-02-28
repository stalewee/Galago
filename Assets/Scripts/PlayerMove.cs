using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody2D rb;
    private float xin = 0f;
    private float yin = 0f;
    private float Kx = 2f;
    private float Ky = 2.5f;
    private float max_vx = 10f;
    private float max_vy = 10f;
    private float dead_vx = 0f;
    private float dead_vy = 0f;
    private float max_x_acc = 250f;
    private float max_y_acc = 250f;
    private Vector2 command_vel;

    public float wall_buff = 0.1f;
    private float max_x;
    private float min_x;
    private float max_y;
    private float min_y;
    public GameObject tw;
    public GameObject bw;
    public GameObject rw;
    public GameObject lw;

    public Transform fpr;
    public Transform fpl;
    private Vector3 bank_R_R;
    private Vector3 bank_R_L;
    private Vector3 bank_L_R;
    private Vector3 bank_L_L;
    private Vector3 init_R;
    private Vector3 init_L;

    private bool paused = false;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        command_vel.x = 0f;
        command_vel.y = 0f;

        max_y = tw.transform.position.y - wall_buff;
        min_y = bw.transform.position.y + wall_buff;
        max_x = rw.transform.position.x - wall_buff;
        min_x = lw.transform.position.x + wall_buff;

        Cursor.visible = paused;
        Cursor.lockState = CursorLockMode.Locked;

        init_R = fpr.localPosition;
        init_L = fpl.localPosition;
        bank_R_R.x = -0.029f;
        bank_R_R.y = 0f;
        bank_R_L.x = 0.012f;
        bank_R_L.y = 0f;
        bank_L_R.x = -0.025f;
        bank_L_R.y = 0f;
        bank_L_L.x = 0.02f;
        bank_L_L.y = 0f;

    }

    // Update is called once per frame
    void Update()
    {
        if (!paused)
        {
            xin = Input.GetAxis("Horizontal");
            yin = Input.GetAxis("Vertical");
            if (Mathf.Abs(xin) < dead_vx)
            {
                xin = 0f;
            }
            if (Mathf.Abs(yin) < dead_vy)
            {
                yin = 0f;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
            Cursor.visible = paused;
            if (paused)
            {
                pauseGame();
                Time.timeScale = 0;
            }
            else
            {
                continueGame();
                Time.timeScale = 1;
            }
        }
    }

    void pauseGame()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    void continueGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void FixedUpdate()
    {
        float x_vel = xin * Kx;
        if (x_vel < -max_vx)
        {
            x_vel = -max_vx;
        }
        if (x_vel > max_vx)
        {
            x_vel = max_vx;
        }
        float x_acc = (x_vel - command_vel.x) / Time.fixedDeltaTime;
        if (x_acc > max_x_acc)
        {
            x_vel = command_vel.x + max_x_acc * Time.fixedDeltaTime;
        }
        else if (x_acc < -max_x_acc)
        {
            x_vel = command_vel.x - max_x_acc * Time.fixedDeltaTime;
        }

        float y_vel = yin * -Ky;
        if (y_vel < -max_vy)
        {
            y_vel = -max_vy;
        }
        if (y_vel > max_vy)
        {
            y_vel = max_vy;
        }
        float y_acc = (y_vel - command_vel.y) / Time.fixedDeltaTime;
        if (y_acc > max_y_acc)
        {
            y_vel = command_vel.y + max_y_acc * Time.fixedDeltaTime;
        }
        else if (y_acc < -max_y_acc)
        {
            y_vel = command_vel.y - max_y_acc * Time.fixedDeltaTime;
        }

        float sx;
        float sy;
        float wall_v_limit;
        if (x_vel > 0)
        {
            sx = max_x - rb.position.x;
            wall_v_limit = Mathf.Sqrt(2 * sx * max_x_acc);
            if (x_vel > wall_v_limit)
            {
                x_vel = wall_v_limit;
            }
        }
        else if (x_vel < 0)
        {
            sx = rb.position.x - min_x;
            wall_v_limit = Mathf.Sqrt(2 * sx * max_x_acc);
            if (x_vel < -wall_v_limit)
            {
                x_vel = -wall_v_limit;
            }
        }
        if(y_vel > 0)
        {
            sy = max_y - rb.position.y;
            wall_v_limit = Mathf.Sqrt(2 * sy * max_y_acc);
            if (y_vel > wall_v_limit)
            {
                y_vel = wall_v_limit;
            }
        }
        else if (y_vel < 0)
        {
            sy = rb.position.y - min_y;
            wall_v_limit = Mathf.Sqrt(2 * sy * max_y_acc);
            if (y_vel < -wall_v_limit)
            {
                y_vel = -wall_v_limit;
            }
        }


        command_vel.x = x_vel;
        command_vel.y = y_vel;
        rb.velocity = command_vel;

        animator.SetFloat("player_Vx", x_vel);
        animator.SetFloat("player_Vy", y_vel);
    }

    void centreFirepoints()
    {
        fpr.localPosition = init_R;
        fpl.localPosition = init_L;
    }

    void rightFirepoints()
    {
        fpr.localPosition = init_R + bank_R_R;
        fpl.localPosition = init_L + bank_R_L;
    }

    void leftFirepoints()
    {
        fpr.localPosition = init_R + bank_L_R;
        fpl.localPosition = init_L + bank_L_L;
    }
}
