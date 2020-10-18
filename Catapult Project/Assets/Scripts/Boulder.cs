using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Boulder : MonoBehaviour
{
    public GameObject FOW;
    public GameObject Player;
    bool haslanded;

    void OnTriggerEnter2D(Collider2D collider)
    {
        
        if (collider.tag == "EndPoint")
        {
            GameObject.Instantiate(FOW, gameObject.transform.position, Quaternion.identity);
                Destroy(collider.gameObject);
                Destroy(gameObject.GetComponent<CircleCollider2D>());
                Destroy(gameObject.GetComponent<Rigidbody2D>());
                GameObject.Find("Catapult").GetComponent<Shoot>().ShotFired = false;
            
        }
    }

    
}
