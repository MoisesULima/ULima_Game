using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovePlatform : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpImpulse;
    [Header("Parámetros para detector de piso")]
    [SerializeField] private Transform detector;
    [SerializeField] private float sizeDetector;
    [SerializeField] private LayerMask groundLayer;

    private InputAction moveAction;
    private InputAction jumpAction;
    private Rigidbody2D body;
    private SpriteRenderer sprite;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
    }

    // Update is called once per frame
    private void Update()
    {
        // Acá detectamos si estamos en el piso.
        Collider2D colision = Physics2D.OverlapCircle(detector.position, sizeDetector, groundLayer);
        // Si existe colisión entonces estamos en el piso y podemos saltar (canJump)
        bool canJump = colision != null;

        Vector2 move = moveAction.ReadValue<Vector2>();

        // Para los juegos de plataforma, la velocidad en Y no se considera m�s que para el salto
        // pero al presionar los dos botones, la velocidad en "x" y "y" se normalizan x = 0.71 y y = 0.71
        int direction = move.x == 0 ? 0 : move.x > 0 ? 1 : -1;
        body.linearVelocityX = direction * speed;

        if (direction != 0)
        {
            sprite.flipX = direction < 0 ? true : false;
        }

        if (jumpAction.WasPressedThisFrame() && canJump)
        {
            Debug.Log("El sapo debe saltar...");
            body.linearVelocityY = jumpImpulse;
        }
    }
}
