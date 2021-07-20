using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    // Start is called before the first frame update
    public Image blackOut;
    
    void Start()
    {
        blackOut.canvasRenderer.SetAlpha(0.0f);
        Fade();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Fade() {
        blackOut.CrossFadeAlpha(1, 5, false);
    }
    
   
    
}
