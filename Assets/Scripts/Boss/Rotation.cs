using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{

    public float xRot;
    public float yRot;
    public float zRot;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(xRot, yRot, zRot) * Time.deltaTime);
    }
}
