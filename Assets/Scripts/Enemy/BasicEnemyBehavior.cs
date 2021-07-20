using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyBehavior : MonoBehaviour
{
    public List<Vector3> waypoints = new List<Vector3>();

    Vector3 currentPos;

    Vector3 nextPos;

    private int count = 0;


    // Start is called before the first frame update
    void Start()
    {
        currentPos = gameObject.transform.position;
        nextPos = waypoints[0];
        

        StartCoroutine(LerpPosition(nextPos, 3));
        
    }

    // Update is called once per frame
   

    IEnumerator LerpPosition(Vector3 targetPosition, float duration)
    {
        
        float time = 0;
        Vector3 startPosition = transform.position;

        while (time < duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;

                
        }
        transform.position = targetPosition;
        count++;
        if (count < waypoints.Count)
        {
            nextPos = waypoints[count];
            StartCoroutine(LerpPosition(nextPos, 3));
            Debug.Log("moving");
        }

        

    }

    
   
}
