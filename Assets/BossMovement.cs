using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public GameObject[] waypoints;
    public GameObject levelSwitcher;
    int current = 0;

    public float Hp = 100f;

    public float speed;
    float WPrad = 1;
    // Start is called before the first frame update
    void Start()
    {
        levelSwitcher.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(waypoints[current].transform.position, transform.position) < WPrad)
        {
            current++;
            if (current >= waypoints.Length)
            {
                current = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, waypoints[current].transform.position, Time.deltaTime * speed);

        if (Hp <= 50f)
        {
            speed = 20f;
        }

        if (Hp <= 0f)
        {
            Destroy(gameObject);
            levelSwitcher.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Hp -= 10f;
        }
    }


}
