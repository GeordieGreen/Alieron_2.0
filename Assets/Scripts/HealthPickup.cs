using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    PlayerHealth player;

    public float hpBoost;

    private void Start()
    {
        player = FindObjectOfType<PlayerHealth>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (player.health < 100)
            {
                player.health += hpBoost;
            }

            Destroy(gameObject);
        }
    }
}
