using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float MovementSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;

    private Rigidbody2D rb2d;
    [SerializeField] private Animator animator;

    private bool isGrounded;
    private bool isClimbing;
    private bool isJumping;

    public Transform GroundCheck;
    public LayerMask GroundLayer;

    private PlayerInputSystem playerControls;

    private Vector2 movement;
    private float scaleX;

    private InputAction move;
    private InputAction jump;

    private bool isRunning;

    private void Awake()
    {
        playerControls = new PlayerInputSystem();
        rb2d = GetComponent<Rigidbody2D>();
        scaleX = transform.localScale.x;
    }

    private void OnEnable()
    {
        move = playerControls.Player.Move;
        move.Enable();
        jump = playerControls.Player.Jump;
        jump.performed += Jump;
        jump.Enable();
    }

    private void OnDisable()
    {
        move.Disable();
        jump.Disable();
    }

    private void Update()
    {
        movement = move.ReadValue<Vector2>();
        Animation();
    }

    private void FixedUpdate()
    {
        rb2d.velocity = new Vector2(movement.x * MovementSpeed, rb2d.velocity.y);
        Flip();

        if (isGrounded && isJumping)
        {
            // Player has landed on the ground, stop the jump animation
            animator.SetBool("IsJumping", false);
            isJumping = false;
        }
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

    private void Jump(InputAction.CallbackContext context)
    {
        CheckIfGrounded();
        if (isGrounded)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);

            animator.SetBool("IsJumping", true);
            isJumping = true;
        }
    }

    public void CheckIfGrounded()
    {
        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, GroundCheck.GetComponent<CircleCollider2D>().radius, GroundLayer);
    }

    private void Animation()
    {
        if (Mathf.Abs(rb2d.velocity.x) >= 0.05f)
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }
        animator.SetBool("IsRunning", isRunning);

        if(!isGrounded)
        {
            CheckIfGrounded();
        }
    }
}