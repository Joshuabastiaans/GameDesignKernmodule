using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchActivate : MonoBehaviour
{
    [SerializeField] private string Message;
    public void Activate()
    {
        Debug.Log(Message);
    }
}
