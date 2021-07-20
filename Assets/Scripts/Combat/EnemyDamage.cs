using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float enemyHp = 50f;

    public GameObject hpDrop;


    public void TakeDamage(float amount)
    {
        enemyHp -= amount;

        if (enemyHp <= 0f)
        {
            Die();
        }

        void Die ()
        {
            Destroy(gameObject);

            if (hpDrop == null)
            {

            }

            else
            {
                Instantiate(hpDrop, transform.position, Quaternion.identity);
            }
            
        }
    }
}
