using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpeed : MonoBehaviour
{
    public float projSpeed;
    private Rigidbody rb;

    private void OnEnable()
    {
        if (rb != null)
        {
            rb.velocity = transform.forward * projSpeed;
        }
        
        Invoke("Disable", 6f);
    }

    private void Start()
    {
        
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * projSpeed;
    }

    void Disable()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}
