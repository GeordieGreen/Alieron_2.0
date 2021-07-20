using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltPool : MonoBehaviour
{
    public GameObject projectile;

    public List<GameObject> objectPool;

    public Transform startLocation;

    public Transform projParent;


    private void Awake()
    {
        for (int i = 0; i < 25; i++)
        {
            GameObject theProjectile = Instantiate(projectile, startLocation.transform.position, startLocation.rotation);
            theProjectile.name = projectile.name;
            //theProjectile.transform.position = startLocation.position;
            //theProjectile.transform.rotation = startLocation.rotation;
            theProjectile.SetActive(true);

            objectPool.Add(theProjectile);
        }

    }


    public void GetObjFromPool()
    {
        for (int i = 0; i < objectPool.Count; i++)
        {
            if (objectPool[i].activeInHierarchy == false)
            {
                objectPool[i].transform.position = startLocation.position;
                objectPool[i].transform.rotation = startLocation.rotation;
                objectPool[i].SetActive(true);


                return;
            }


        }

        //Nothing usable in pool

        AddObject();
    }

    //Creating and setting up a new object to pool
    void AddObject()
    {
        GameObject theProjectile = Instantiate(projectile, startLocation.transform.position, startLocation.rotation);
        theProjectile.name = projectile.name;

        theProjectile.SetActive(true);

        objectPool.Add(theProjectile);


    }

}
