using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamManager : MonoBehaviour
{
    [SerializeField] private Camera cutsceneCam;
    [SerializeField] private Camera playerCam;
    [SerializeField] private GameObject blackBars;
    
    // Start is called before the first frame update
    void Start()
    {
        cutsceneCam.enabled = true;
        playerCam.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("CamSwitch", 6.0f);  
    }

    void CamSwitch()
    {
        cutsceneCam.enabled = false;
        playerCam.enabled = true;
        blackBars.SetActive(false);
    }

}
