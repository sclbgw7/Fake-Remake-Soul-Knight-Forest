using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;

public class PlayerMove : MonoBehaviour
{
    public float LineSpeed;
    private float LastForward;
    private Rigidbody2D RB;
    private Animator AM;
    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        AM = GetComponent<Animator>();
        LastForward = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        //transform.rotation.Reset(); // = new Vector3(0, 0, 0);
        float moveUp = Input.GetAxis("Vertical");
        float moveRight = Input.GetAxis("Horizontal");
        //朝向
        if(moveRight * LastForward < 0) {
            transform.localScale = new Vector3 ( (moveRight > 0 ? 1 : -1), 1, 1);
            if(moveRight < 0)transform.position += new Vector3(-1.62f, 0, 0);
            else transform.position += new Vector3(1.62f, 0, 0);
            LastForward = -LastForward;
        }

        float offset = (float)Sqrt(moveUp * moveUp + moveRight * moveRight);
        //动画
        AM.SetFloat("run", offset);

        //移动
        if(offset < 1)offset = 1;
        RB.velocity = new Vector2(moveRight, moveUp) * LineSpeed / offset;
    }
}
