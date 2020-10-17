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
    public GameObject BulletPrefab;
    public float BulletSpeed = 25.0f;
    public GameObject EndPoint;
    
    private bool shotFired;

    public bool ShotFired
    {
        set => shotFired = value;
    }   
 

    private void Fire()
    {
        Vector2 target = GameObject.FindWithTag("EndPoint").GetComponent<Transform>().transform.position - gameObject.transform.position;
        float targetMidPoint = target.y / 2.0f;
        Debug.Log(target.x);
        Debug.Log(target.y);
        GameObject bullet = Instantiate(BulletPrefab, transform.position, transform.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(target * BulletSpeed);
        

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !shotFired)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 0;
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            ShotFired = true;
            Instantiate(EndPoint, worldPos, Quaternion.identity);

            Fire();
        }
    }

}