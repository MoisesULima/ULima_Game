using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed;

    private InputAction moveAction;
    private Rigidbody2D body;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
    }

    // Update is called once per frame
    private void Update()
    {
        Vector2 move = moveAction.ReadValue<Vector2>();

        body.linearVelocityX = move.x * speed;
        body.linearVelocityY = move.y * speed;
    }
}
