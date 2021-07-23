using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetScale : MonoBehaviour
{
    // Start is called before the first frame update

    public float scaleSpeed;
    Vector3 scale;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Scaler()
    {
        scale = transform.localScale;

        scale.x += 1f * Time.deltaTime;
        scale.y += 1f * Time.deltaTime;

        transform.localScale = scale;
    }


}
