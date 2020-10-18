using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    /*
     * BulletPrefab: add boulder to shoot.
     * BulletSpeed: How Fast bullet arrives at destination.
     * Endpoint: Game object that the bullet is launched towards. Invisible
     */
    public GameObject BulletPrefab,Bullet2;
    public float BulletSpeed = 25.0f, rapidShotTimer = 3f;
    public GameObject EndPoint;
    private GameObject T;
    public Player p => FindObjectOfType<Player>();
    
    private bool shotFired;

    public bool ShotFired
    {
        set => shotFired = value;
    }   
 

    private void Fire()
    {
        Vector2 target = GameObject.FindWithTag("EndPoint").GetComponent<Transform>().transform.position - gameObject.transform.position;
        GameObject bullet = Instantiate(T, transform.position, transform.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(target * BulletSpeed);
        

    }

    void Update()
    {
        
        
        if (p.paused == false && p.alive) {
            if (Input.GetMouseButtonDown(0) && !shotFired)
            {
                Vector3 mousePos = Input.mousePosition;
                mousePos.z = 0;
                Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
                ShotFired = true;
                Instantiate(EndPoint, worldPos, Quaternion.identity);
                T = BulletPrefab;
                Fire();
            }
            if (Input.GetMouseButtonDown(1) && !shotFired)
            {
                Vector3 mousePos = Input.mousePosition;
                mousePos.z = 0;
                Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
                ShotFired = true;
                Instantiate(EndPoint, worldPos, Quaternion.identity);
                T = Bullet2;
                Fire();
            }
        }
    }

}