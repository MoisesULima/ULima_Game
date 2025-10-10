using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerGrab : MonoBehaviour
{
    [SerializeField] private Transform grabZone;

    private InputAction interactAction;
    private EnemyGrabable enemy;

    private void Start()
    {
        interactAction = InputSystem.actions.FindAction("Interact");
        enemy = null;
    }

    private void Update()
    {
        if (enemy != null)
        {
            if (interactAction.WasPressedThisFrame())
            {
                enemy.ChangeEnemyStatus(grabZone);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyGrab"))
        {
            enemy = collision.gameObject.GetComponent<EnemyGrabable>();
        }
    }
}
