using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public Player player;
    public TMP_Text t;
    private int mod = 1;
    public void Heal()
    {
        if (player.Gold >= mod && player.currentHealth < player.MaxHealth)
        {
            player.Gold -= mod;
            mod++;
            player.currentHealth += 1;

        }


    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        t.text = "Heal + " + mod;
    }
}
