using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public bool paused, alive;
    public int MaxHealth=10, Gold=0, currentHealth;
    public Slider healthbar;
    public GameObject PausedText, Panel;

    public void Start()
    {
        healthbar.maxValue = MaxHealth;
        currentHealth = MaxHealth;
        alive = true;
    }

    void Update()
    {
        Panel.active = !alive;

        healthbar.value = currentHealth;
        PausedText.active = paused;
        if (currentHealth <= 0) {
            alive = false;
            
            //GameOver
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            paused = !paused;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy") {
            currentHealth -= 1;
        }
    }
}
