using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    private InputAction interactAction;

    private DoorControl currentDoor;

    private void Start()
    {
        interactAction = InputSystem.actions.FindAction("Interact");
        currentDoor = null;
    }

    private void Update()
    {
        if (currentDoor != null)
        {
            if (interactAction.WasPressedThisFrame())
            {
                currentDoor.ChangeDoorStatus();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DoorControl"))
        {
            currentDoor = collision.gameObject.GetComponent<DoorControl>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DoorControl"))
        {
            currentDoor = null;
        }
    }
}
