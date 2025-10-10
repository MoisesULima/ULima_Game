using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private float speed;

    private InputAction moveAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
    }

    // Update is called once per frame
    private void Update()
    {
        Vector2 move = moveAction.ReadValue<Vector2>();

        Vector3 pos = transform.localPosition;
        float newX = pos.x + move.x * speed * Time.deltaTime;
        float newY = pos.y + move.y * speed * Time.deltaTime;
        transform.localPosition = new Vector3(newX, newY, pos.z);
    }
}
