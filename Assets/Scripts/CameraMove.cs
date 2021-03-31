using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform Follow;
    public float FollowSpeed;
    private Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        velocity = Vector3.zero;
    }
    
    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = new Vector3(Follow.position.x, Follow.position.y, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, 0.2f);//FollowSpeed * Time.deltaTime);
        //Mathf.SmoothDamp(transform.position.x, target.position.x,  ref  velocity.x, smoothTime
    }
}
