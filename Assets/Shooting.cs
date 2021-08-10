using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPf;

    private float allowedToShoot = 0f;
    private float timeToNextShoot = 1f;

    public float bForce = 20f;
    // Update is called once per frame
    void Update()
    {
        CanShoot();

    }
    void CanShoot()
    {
        if (allowedToShoot <= Time.time)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Shoot();
                allowedToShoot = Time.time + timeToNextShoot;
            }
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPf, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(firePoint.forward * bForce, ForceMode.Impulse);
    }
}
