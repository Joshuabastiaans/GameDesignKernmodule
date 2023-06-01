using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GuardMovement : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public Transform pointA;
    public Transform pointB;
    public float walkingSpeed = 2f;
    public float pauseDuration = 1f;

    private Transform currentTarget;
    private bool isWalking = true;
    private float scaleX;


    private void Start()
    {
        currentTarget = pointA;
        scaleX = transform.localScale.x;
    }

    private void Animation()
    {
        animator.SetBool("IsRunning", isWalking);
    }


    private void Update()
    {
        if (isWalking)
        {
            MoveToTarget(currentTarget);
        }
        Animation();
    }


    private void MoveToTarget(Transform target)
    {
        Vector3 direction = (target.position - transform.position).normalized;

        FlipSprite(direction.x);

        transform.Translate(direction * walkingSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            StartCoroutine(PauseBeforeNextTarget());
        }
    }

    private void FlipSprite(float direction)
    {
        if (direction > 0)
        {
            transform.localScale = new Vector3(scaleX, transform.localScale.y, transform.localScale.z);
        }
        else if (direction < 0)
        {
            transform.localScale = new Vector3((-1) * scaleX, transform.localScale.y, transform.localScale.z);
        }
    }

    private IEnumerator PauseBeforeNextTarget()
    {
        isWalking = false;
        yield return new WaitForSeconds(pauseDuration);
        isWalking = true;

        // Change the target point
        if (currentTarget == pointA)
        {
            currentTarget = pointB;
        }
        else
        {
            currentTarget = pointA;
        }
    }
}
