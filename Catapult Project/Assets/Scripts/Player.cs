using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Player : MonoBehaviour
{
    public bool paused, alive;
    public int MaxHealth=10, Gold=0, currentHealth;
    public Slider healthbar;
    public GameObject PausedText, Panel,trap;
    public TMP_Text goldText, ZombieCounter;
    public Animator A;
    public int walls,traps,kills;

    public void Start()
    {
        healthbar.maxValue = MaxHealth;
        currentHealth = MaxHealth;
        alive = true;
    }

    void Update()
    {
        ZombieCounter.text = "Zombies killed " + kills ;
        if (traps >= 1 && Input.GetMouseButtonDown(2))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 0;
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            Instantiate(trap, worldPos + new Vector3(0,0,10), Quaternion.identity);
            traps -= 1;
        }

        goldText.text = Gold.ToString();
        Panel.active = !alive;

        healthbar.value = currentHealth;
        PausedText.active = paused;
        if (currentHealth <= 0) {
            alive = false;
            
            //GameOver
        }
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.P)) {
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
