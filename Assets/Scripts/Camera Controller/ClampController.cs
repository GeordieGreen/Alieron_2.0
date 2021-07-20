using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClampController : MonoBehaviour
{
    public Camera vCam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        ClampPosition();
    }

    void ClampPosition()
    {
        Vector3 pos = vCam.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp01(pos.y);
        transform.position = vCam.ViewportToWorldPoint(pos);
    }
}
