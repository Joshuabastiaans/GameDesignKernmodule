using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SwitchActivate : MonoBehaviour
{
    [SerializeField] private string Message;
    private Animator anim;
    private bool isReversed;
    public UnityEvent ActivateSwitch;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }   
    public void Activate()
    {
        Debug.Log(Message);
        anim.SetTrigger("Activate");
        isReversed =!isReversed;
        anim.SetBool("IsReversed", isReversed); 
        ActivateSwitch?.Invoke();
    }
}
