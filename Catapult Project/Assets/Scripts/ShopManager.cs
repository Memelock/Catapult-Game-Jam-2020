using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public Player player;
    public TMP_Text t,SafeTextCost,TrapCost, wallcount;
    private int healthmod = 1, safemod = 5, wallmod = 2;
    public GameObject PrimaryCircle, SecondaryCircle;




    public void Heal()
    {
        if (player.Gold >= healthmod && player.currentHealth < player.MaxHealth && !player.paused)
        {
            player.Gold -= healthmod;
            healthmod++;
            player.currentHealth += 1;
        }
        
    }

    public void SafeModifier()
    {

        if (player.Gold >= safemod && !player.paused)
        {
            player.Gold -= safemod;
            PrimaryCircle.transform.localScale = new Vector3(PrimaryCircle.transform.localScale.x + .5f, PrimaryCircle.transform.localScale.y + .5f);
            SecondaryCircle.transform.localScale = new Vector3(SecondaryCircle.transform.localScale.x + .5f, SecondaryCircle.transform.localScale.y + .5f);
            safemod += 5;
        }


    }

    public void WallAdder()
    {

        if (player.Gold >= wallmod && !player.paused)
        {
            player.Gold -= wallmod;
            player.walls += 1;
            
        }


    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        t.text = "Heal + " + healthmod;
        SafeTextCost.text = "Expand Light + " + safemod;
        TrapCost.text = "Add trap + " + wallmod;
        wallcount.text = player.walls.ToString();

    }
}
