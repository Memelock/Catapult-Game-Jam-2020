using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    public Transform target;

    public float speed = 200f;
    public float nextWaypointDistance = 3;

    public Transform enemyGFX;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;

    public Vector2 force;

    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        target = GameObject.FindGameObjectWithTag("Player").transform;

        InvokeRepeating("UpdatePath", 0f, .5f);
    }

    void UpdatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (path == null)
            return;

        if(currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if(distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

        if(force.x >= 0.01f)
        {
            //enemyGFX.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if(force.x <= -0.01f)
        {
            //enemyGFX.localScale = new Vector3(1f, 1f, 1f);
        }

    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        rb.AddForce(force, ForceMode2D.Impulse);
        Debug.Log("impulse");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Ally")
        {
            target = col.transform;
            rb.velocity = new Vector2(0, 0);
            StartCoroutine(ExecuteAfterTime(.5f));
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Ally")
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
            rb.AddForce(force);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ally")
        {
            //Destroy(col.gameObject);
        }
    }
}
