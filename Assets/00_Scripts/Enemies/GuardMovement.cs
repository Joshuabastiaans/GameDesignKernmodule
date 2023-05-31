using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardMovement : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private Rigidbody2D rb2d;


    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

}
