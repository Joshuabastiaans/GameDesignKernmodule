using UnityEngine;
using UnityEngine.InputSystem;

public class Interact : MonoBehaviour
{
    //script that lets the player interact with object

    private PlayerInputSystem playerControls;
    private InputAction triggerSwitch;

    public virtual void Awake()
    {
        playerControls = new PlayerInputSystem();
    }

    public virtual void OnEnable()
    {
        triggerSwitch = playerControls.Player.Switch;
        triggerSwitch.performed += OnTriggerSwitch;
        triggerSwitch.Enable();
    }

    public virtual void OnDisable()
    {
        triggerSwitch.Disable();
    }

    public virtual void OnTriggerSwitch(InputAction.CallbackContext context)
    {
        //interact logic here
    }
}
