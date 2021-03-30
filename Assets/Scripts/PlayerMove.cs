using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;

public class PlayerMove : MonoBehaviour
{
    public float LineSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveUp = Input.GetAxis("Vertical");
        float moveRight = Input.GetAxis("Horizontal");
        float offset = (float)Sqrt(moveUp + moveRight);
        transform.position += new Vector3(moveRight  * LineSpeed, moveUp * LineSpeed, 0) * Time.deltaTime;
    }
}
