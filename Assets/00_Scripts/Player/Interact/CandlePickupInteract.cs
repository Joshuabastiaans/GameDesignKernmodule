using UnityEngine;
using UnityEngine.InputSystem;

public class CandlePickupInteract : Interact
{
    public LayerMask candleLayer; 

    public override void OnTriggerSwitch(InputAction.CallbackContext context)
    {
        Collider2D collider = Physics2D.OverlapCircle(transform.position, 1f, candleLayer);


        if (collider != null)
        {
            CandlePickup candlePickup = collider.GetComponent<CandlePickup>();

            candlePickup.Pickup();
        }

    }
}
