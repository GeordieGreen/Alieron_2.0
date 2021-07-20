using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechLockOn : MonoBehaviour
{

    [SerializeField] private Transform boss;
    [SerializeField] private Rigidbody rb;

    public GameObject projectile;
    public Transform firePos;
    
    
    public float hSpeed = 50f;
    public float vSpeed = 50f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        float h = hSpeed * Input.GetAxis("Horizontal");
        float v = vSpeed * Input.GetAxis("Vertical");

        //transform.Translate(h, v, 0);
        transform.RotateAround(boss.transform.position, Vector3.down, h * Time.deltaTime);
        //transform.RotateAround(boss.transform.position, Vector3.zero, v * Time.deltaTime);

        rb.velocity = new Vector3(0, v, 0);

        transform.LookAt(boss);

        if (Input.GetButtonDown("Fire1"))
        {
            shoot();
        }
    }

    private void shoot()
    {
        GameObject obj = ProjectilePool.current.GetPooledObj();
        if (obj == null) return;
        obj.transform.position = firePos.position;
        obj.transform.rotation = firePos.rotation;
        obj.SetActive(true);
        
    }
}
