using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechCam : MonoBehaviour
{
    public Transform target;
    public float smooth = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, Time.deltaTime * smooth);
          
    }
}
