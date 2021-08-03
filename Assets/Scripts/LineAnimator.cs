using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineAnimator : MonoBehaviour
{

    public float animDuration = 5f;

    private LineRenderer lineRenderer;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();

        StartCoroutine(AnimateLine());
    }

    private IEnumerator AnimateLine() 
    {
        float startTime = Time.time;

        Vector3 startPos = lineRenderer.GetPosition(0);
        Vector3 endPos = lineRenderer.GetPosition(1);

        Vector3 pos = startPos;
        while (pos != endPos)
        {
            float t = (Time.time - startTime) / animDuration;
            pos = Vector3.Lerp(startPos, endPos, t);
            lineRenderer.SetPosition(1, pos);
            yield return null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
