using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float MovementSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;

    private Rigidbody2D rb2d;
    private Animator animator;

    [SerializeField] private bool isGrounded;
    [SerializeField] private bool isClimbing;

    [SerializeField] private PlayerInputSystem playerControls;

    private InputAction move;



}
