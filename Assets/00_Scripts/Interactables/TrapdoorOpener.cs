using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapdoorOpener : MonoBehaviour
{
    [SerializeField] private Animator animator1;
    [SerializeField] private Animator animator2;

    private bool openDoor;

    public void OpenTrapdoor()
    {
        openDoor = !openDoor;
        animator1.SetBool("OpenDoor", openDoor);
        animator2.SetBool("OpenDoor", openDoor);
    }
}