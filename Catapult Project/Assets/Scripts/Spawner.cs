using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject [] Enemys;
    public float WaveTimer=20f, o;
    public int level = 1;
    public GameObject S, Necro;
    public Player p => FindObjectOfType<Player>();

    // Start is called before the first frame update
    void Start()
    {
        o = WaveTimer;
        gameObject.transform.position = new Vector2(Random.Range(7f, 50f), Random.Range(7f, 50f));
    }

    // Update is called once per frame
    void Update()
    {
        if (!p.paused)
        {
            if (WaveTimer > 0f)
            {
                WaveTimer -= Time.deltaTime;
            }
            else
            {

                for (int i = 0; i < level; i++)
                {
                    Vector2 positions = new Vector2(Random.Range(gameObject.transform.position.x - 20f, gameObject.transform.position.x + 3f), Random.Range(gameObject.transform.position.y - 20f, gameObject.transform.position.y + 3f));
                    GameObject.Instantiate(Enemys[0], positions, Quaternion.identity);
                }
                level++;
                o -= level / 10;
                WaveTimer = o;
            }
            if (level % 10 == 0)
            {

                level /= 10;
                Vector2 positions = new Vector2(Random.Range(gameObject.transform.position.x - 20f, gameObject.transform.position.x + 3f), Random.Range(gameObject.transform.position.y - 20f, gameObject.transform.position.y + 3f));
                GameObject.Instantiate(Necro, positions, Quaternion.identity);
            }
            if (level % 15 == 0)
            {
                Vector2 positions = new Vector2(Random.Range(gameObject.transform.position.x - 20f, gameObject.transform.position.x + 3f), Random.Range(gameObject.transform.position.y - 20f, gameObject.transform.position.y + 3f));
                GameObject.Instantiate(S, positions, Quaternion.identity);
                level /= 15;
            }
            if (o < 2)
            {
                o = 5;
            }
        }
    }
}
