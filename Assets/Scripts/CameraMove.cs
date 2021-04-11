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
        //velocity = Vector3.zero;
    }
    
    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 targetPos = new Vector3(Follow.position.x, Follow.position.y, transform.position.z);
        //Vector3 diffPos = targetPos - transform.position;
       //transform.position = ;
        //transform.position = Vector3.Lerp(transform.position, targetPos, FollowSpeed * Time.deltaTime);
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref  velocity, FollowSpeed);
        //Mathf.SmoothDamp(transform.position.x, target.position.x,  ref  velocity.x, smoothTime
    }
}
