using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamManager : MonoBehaviour
{
    [SerializeField] private Camera cutsceneCam;
    [SerializeField] private Camera cutsceneCam2;
    [SerializeField] private Camera cutsceneCam3;
    [SerializeField] private Camera cutsceneCam4;
    [SerializeField] private Camera cutsceneCam5;
    [SerializeField] private Camera cutsceneCam6;
    [SerializeField] private Camera playerCam;
    public GameObject mech;
    public GameObject boss;
    public GameObject bounds3;
    [SerializeField] private GameObject blackBars;

    
    
    // Start is called before the first frame update
    void Start()
    {
        //mech = GetComponent<GameObject>();
        cutsceneCam.enabled = true;
        cutsceneCam2.enabled = false;
        cutsceneCam3.enabled = false;
        cutsceneCam4.enabled = false;
        cutsceneCam5.enabled = false;
        cutsceneCam6.enabled = false;
        playerCam.enabled = false;
        mech.SetActive(false);
        boss.SetActive(false);
        bounds3.SetActive(false);
        
        Invoke("CamSwitch1", 5f);
        Invoke("CamSwitch2", 10f);
        Invoke("CamSwitch3", 15f);
        Invoke("CamSwitch4", 20f);
        Invoke("CamSwitch5", 23f);
        Invoke("MechEnabled", 24.167f);
        Invoke("CamSwitch6", 25.1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CamSwitch1()
    {
        cutsceneCam.enabled = false;
        cutsceneCam2.enabled = true;
        cutsceneCam3.enabled = false;
        cutsceneCam4.enabled = false;
        cutsceneCam5.enabled = false;
        cutsceneCam6.enabled = false;
        playerCam.enabled = false;
        //blackBars.SetActive(false);
    }

    void CamSwitch2()
    {
        cutsceneCam.enabled = false;
        cutsceneCam2.enabled = false;
        cutsceneCam3.enabled = true;
        cutsceneCam4.enabled = false;
        cutsceneCam5.enabled = false;
        cutsceneCam6.enabled = false;
        playerCam.enabled = false;
        //blackBars.SetActive(false);
    }

    void CamSwitch3()
    {
        cutsceneCam.enabled = false;
        cutsceneCam2.enabled = false;
        cutsceneCam3.enabled = false;
        cutsceneCam4.enabled = true;
        cutsceneCam5.enabled = false;
        cutsceneCam6.enabled = false;
        playerCam.enabled = false;
        //blackBars.SetActive(false);
    }

    void CamSwitch4()
    {
        cutsceneCam.enabled = false;
        cutsceneCam2.enabled = false;
        cutsceneCam3.enabled = false;
        cutsceneCam4.enabled = false;
        cutsceneCam5.enabled = true;
        cutsceneCam6.enabled = false;
        playerCam.enabled = false;
        //blackBars.SetActive(false);
    }
    void CamSwitch5()
    {
        cutsceneCam.enabled = false;
        cutsceneCam2.enabled = false;
        cutsceneCam3.enabled = false;
        cutsceneCam4.enabled = false;
        cutsceneCam5.enabled = false;
        cutsceneCam6.enabled = true;
        playerCam.enabled = false;
        //blackBars.SetActive(false);
    }
    void CamSwitch6()
    {
        cutsceneCam.enabled = false;
        cutsceneCam2.enabled = false;
        cutsceneCam3.enabled = false;
        cutsceneCam4.enabled = false;
        cutsceneCam5.enabled = false;
        cutsceneCam6.enabled = false;
        playerCam.enabled = true;
        blackBars.SetActive(false);
    }
    void MechEnabled()
    {
        mech.SetActive(true);
        boss.SetActive(true);
        bounds3.SetActive(true);
    }

}
