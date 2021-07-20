using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    private EnemyProjectilePool objectPool;


    

    private void Awake()
    {
        objectPool = GetComponent<EnemyProjectilePool>();
        
    }

  
    // Update is called once per frame
    void Update()
    {
        
    }

    void Shoot()
    {
        objectPool.GetObjFromPool();


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            InvokeRepeating("Shoot", 1.0f, 1.0f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            CancelInvoke("Shoot");
        }
        
    }



}
