using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image Health;

    public float currentHealth;
    public float maxHealth = 100f;

    PlayerHealth player;

   
    void Start()
    {
        Health = GetComponent<Image>();
        player = FindObjectOfType<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = player.health;
        Health.fillAmount = currentHealth / maxHealth;
    }
}
