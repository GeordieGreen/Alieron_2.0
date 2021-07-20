using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletSpeed : MonoBehaviour
{
    public float bulletSpeed = 50f;
    public float bulletLife = 10f;

    public float damage = 10f;

    private float bulletTime;

    private Rigidbody rb;

    PlayerHealth player;



    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        player = FindObjectOfType<PlayerHealth>();
    }


    private void OnEnable()
    {
        bulletTime = bulletLife;
        rb.velocity = transform.up * bulletSpeed;

    }




    void Update()
    {
        bulletTime -= Time.deltaTime;
        if (bulletTime <= 0f)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            player.health -= 10f;

        }
    }
}