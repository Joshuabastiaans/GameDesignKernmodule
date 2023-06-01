using UnityEngine;
using UnityEngine.InputSystem;

public class SwitchInteract : Interact
{
    //script that lets the player interact with switch

    public override void OnTriggerSwitch(InputAction.CallbackContext context)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 1f); // Check for colliders

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
