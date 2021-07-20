using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Death();
    }

    void Death()
    {
        if (health <= 0)
        {
            SceneManager.LoadScene(0); 
        }
    }

}
