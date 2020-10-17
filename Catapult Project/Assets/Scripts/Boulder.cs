using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Boulder : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "EndPoint")
        {
            Destroy(collider.gameObject);
            Destroy(gameObject.GetComponent<Rigidbody2D>());

            GameObject.Find("StartPoint").GetComponent<Shoot>().ShotFired = false;
        }
    }
}
