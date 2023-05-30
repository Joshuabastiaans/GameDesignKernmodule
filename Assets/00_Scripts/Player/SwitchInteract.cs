using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwitchInteract : MonoBehaviour
{
    //script that lets the player interact with switch

    private PlayerInputSystem playerControls;
    private InputAction triggerSwitch;


    private void Awake()
    {
        playerControls = new PlayerInputSystem();

    }

    private void OnEnable()
    {
        triggerSwitch = playerControls.Player.Switch;
        triggerSwitch.performed += OnTriggerSwitch;
        triggerSwitch.Enable();
    }

    private void OnDisable()
    {
        triggerSwitch.Disable();
    }

    private void OnTriggerSwitch(InputAction.CallbackContext context)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 5f); // Check for colliders

        SwitchActivate closestSwitch = null;
        float closestDistance = float.MaxValue;

        foreach (Collider2D collider in colliders)
        {
            SwitchActivate switchComponent = collider.GetComponent<SwitchActivate>();

            if (switchComponent != null)
            {
                float distance = Vector2.Distance(transform.position, switchComponent.transform.position);
                if (distance < closestDistance)
                {
                    closestSwitch = switchComponent;
                    closestDistance = distance;
                }
            }
        }
        if (closestSwitch != null)
        {
            closestSwitch.Activate(); 
        }
    }
}
