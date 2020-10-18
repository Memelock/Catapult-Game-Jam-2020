using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Boulder : MonoBehaviour
{
    public GameObject FOW;
    public GameObject Player;
    public bool haslanded = false;
    public Rigidbody2D rb;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        
        if (collider.tag == "EndPoint")
        {
            GameObject.Instantiate(FOW, gameObject.transform.position, Quaternion.identity);
            Destroy(collider.gameObject);
            //Destroy(gameObject.GetComponent<Rigidbody2D>());
            rb.velocity = new Vector2(0, 0);
            GameObject.Find("Catapult").GetComponent<Shoot>().ShotFired = false;
            haslanded = true;

            StartCoroutine(ExecuteAfterTime(.2f));
        }
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        haslanded = false;
        Destroy(gameObject.GetComponent<CircleCollider2D>());
    }


}
