using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class SloMo : MonoBehaviour
{
    // Start is called before the first frame update

    public PostProcessVolume volume;
    public Canvas canvas;
    private DepthOfField dOF;

    void Start()
    {
        volume.profile.TryGetSettings(out dOF);
        canvas.enabled = false;
    }

    private void Update()
    {
        DismissPrompt();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Time.timeScale = 0.1f;
            Time.fixedDeltaTime = 0.02F * Time.timeScale;
            dOF.focusDistance.value = 2.5f;
            dOF.aperture.value = 16f;
            dOF.focalLength.value = 164f;
            canvas.enabled = true;
            
        }
    }
    private void DismissPrompt()
    {
        if (Input.GetKey(KeyCode.Joystick1Button1))
        {
            Time.timeScale = 1f;
            dOF.focusDistance.value = 0.1f;
            dOF.aperture.value = 0.1f;
            dOF.focalLength.value = 1f;
            canvas.enabled = false;
        }
        if (Input.GetKey(KeyCode.E))
        {
            Time.timeScale = 1f;
            dOF.focusDistance.value = 0.1f;
            dOF.aperture.value = 0.1f;
            dOF.focalLength.value = 1f;
            canvas.enabled = false;
        }
    }
}
