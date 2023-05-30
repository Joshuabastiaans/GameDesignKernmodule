using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float MovementSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;

    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] private Animator animator;

    private bool isGrounded;
    private bool isClimbing;

    public Transform GroundCheck;
    public LayerMask GroundLayer;

    private PlayerInputSystem playerControls;

    private Vector2 movement;
    private float scaleX;

    private InputAction move;

    private void Awake()
    {
        playerControls = new PlayerInputSystem();
        scaleX = transform.localScale.x;
    }

    private void OnEnable()
    {
        move = playerControls.Player.Move;
        move.Enable();
    }

    private void OnDisable()
    {
        move.Disable();
    }

    private void Update()
    {
        movement = move.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        rb2d.velocity = new Vector2(movement.x * MovementSpeed, rb2d.velocity.y);
        Flip();
    }

    public void Flip()
    {
        if (movement.x > 0)
        {
            transform.localScale = new Vector3(scaleX, transform.localScale.y, transform.localScale.z);
        }
        if (movement.x < 0)
        {
            transform.localScale = new Vector3((-1) * scaleX, transform.localScale.y, transform.localScale.z);
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CheckIfGrounded();
            if (isGrounded)
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
            }
        }
    }

    public void CheckIfGrounded()
    {
        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, GroundCheck.GetComponent<CircleCollider2D>().radius, GroundLayer);
    }


}