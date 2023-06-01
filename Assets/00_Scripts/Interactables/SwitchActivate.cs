using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SwitchActivate : MonoBehaviour
{
    private Animator anim;
    private bool isReversed;
    public UnityEvent ActivateSwitch;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }   
    public void Activate()
    {
        anim.SetTrigger("Activate");
        isReversed =!isReversed;
        anim.SetBool("IsReversed", isReversed); 
        ActivateSwitch?.Invoke();
    }
}
