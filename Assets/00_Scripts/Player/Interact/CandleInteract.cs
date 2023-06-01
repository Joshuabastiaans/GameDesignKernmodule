using UnityEngine;
using UnityEngine.InputSystem;

public class CandleInteract : Interact
{
    Inventory inventory;
    public LayerMask torchLayer;


    public override void Awake()
    {
        base.Awake();
        inventory = GetComponent<Inventory>();
    }
    public override void OnTriggerSwitch(InputAction.CallbackContext context)
    {
        // if player is holding candle, then player can interact with torch
        if (inventory.HasTorch())
        {
            //torch interaction logic here
            Collider2D collider = Physics2D.OverlapCircle(transform.position, 1f, torchLayer); // Check for colliders

            if (collider != null)
            {
                Torch torch = collider.GetComponent<Torch>();

                torch.Interact();
            }
        }
    }
}
