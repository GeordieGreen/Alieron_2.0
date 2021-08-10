using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpeed : MonoBehaviour
{
    public GameObject particleEffect;
    
    private void OnCollisionEnter(Collision collision)
    {
        GameObject effect = Instantiate(particleEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        Destroy(gameObject);
    }
}
