using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool paused;
    public int Health=10, Gold=0;

    void Update()
    {
        if (Health <= 0) {
            //GameOver
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            paused = !paused;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy") {
            Health -= 1;
        }
    }
}
