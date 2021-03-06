﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class entity : MonoBehaviour
{
    public int Health,Attack,Gold, MaxGold;
    public Player Player => FindObjectOfType<Player>();
    // Start is called before the first frame update
    void Start()
    {
        
        Gold = Random.Range(1,MaxGold);
    }

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0) {
            Player.Gold += Gold;
            Player.kills += 1;
            GameObject.Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Boulder" && collision.gameObject.GetComponent<Boulder>().haslanded)
        {
            Health -= 1;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player.Gold += 1;
        GameObject.Destroy(gameObject);

    }
}
