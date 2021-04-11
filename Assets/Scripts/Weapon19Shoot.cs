using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;

public class Weapon19Shoot : MonoBehaviour
{
    public GameObject Bullet;
    public PlayerMove Player;
    public Transform GunCenter;
    public float Frequency;
    
    private float lastTime = 0;
    private bool checkFire() {
        if(lastTime < (1f / Frequency))
            return false;
        lastTime = 0;
        return true;
    }

    // Start is called before the first frame update
    void Start()
    {
        ;
    }

    // Update is called once per frame
    void Update()
    {
        //朝向
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Vector2 playerPos = new Vector2(Player.transform.position.x, Player.transform.position.y);
        Vector2 playerPos = new Vector2(GunCenter.position.x, GunCenter.position.y);
        float diffX = mousePos.x - playerPos.x, diffY = mousePos.y - playerPos.y;
        //Debug.Log($"{mousePos.x} {mousePos.y}");
        if(Abs(diffX) > 0.001) {
            Player.SetDirect(diffX);
            float angle = (float)Atan(diffY / diffX) * Mathf.Rad2Deg;
            if(diffX * Player.GetDir() < 0)angle = angle + 180;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        //射击
        lastTime += Time.deltaTime;
        if(Input.GetButtonDown("Fire1"))
        {
            //射速
            if(checkFire()) {
                GameObject NewBullet = Instantiate(Bullet, GunCenter.position, transform.rotation);
                NewBullet.SetActive(true);
                NewBullet.GetComponent<Bullet5>().SetDirect(Player.GetDir() );
            }
        }
    }
}
