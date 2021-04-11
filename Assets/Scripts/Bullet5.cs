using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;

public class Bullet5 : MonoBehaviour
{
    public float LineSpeed;
    private float NowForward;

    public void SetDirect(float dir)
    {
        NowForward = dir > 0 ? 1f : -1f;
        if(Abs(dir) <= 1f)
            NowForward = -NowForward;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag.CompareTo("Player") != 0)
            Destroy(gameObject, 0.01f);
    }

    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "Bullet";
        Destroy(gameObject, 2f);
        float angle = transform.rotation.eulerAngles.z * Mathf.Deg2Rad;
        //Debug.Log($"{angle}");
        //SetDirect(1f);
        GetComponent<Rigidbody2D>().velocity = new Vector2((float)Cos(angle), (float)Sin(angle)) * LineSpeed * NowForward;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
