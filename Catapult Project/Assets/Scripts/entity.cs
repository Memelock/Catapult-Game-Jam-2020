using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class entity : MonoBehaviour
{
    public int Health,Attack,Gold;
    public Player Player => FindObjectOfType<Player>();
    // Start is called before the first frame update
    void Start()
    {
        Gold = Random.Range(1,5);
    }

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0) {
            Player.Gold += Gold;
            GameObject.Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bolder")
        {
            Health -= 1;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject.Destroy(gameObject);
    }
}
