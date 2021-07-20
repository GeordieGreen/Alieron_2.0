using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimPlayer : MonoBehaviour
{
    //public Animator anim;

    [SerializeField] private Animator fallingPillars;
    [SerializeField] private string Falling_Pillars_anim = "Falling_Pillars_anim";

    // Start is called before the first frame update


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            fallingPillars.Play(Falling_Pillars_anim, 0, 0.0f);
        }
        //Debug.Log("Work now");
        //anim.Play("Moving_Pillars_anim");
        
    }


}
