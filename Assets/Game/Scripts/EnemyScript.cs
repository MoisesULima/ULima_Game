using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private float speedX;
    [SerializeField] private float limitRight;
    [SerializeField] private float limitLeft;

    private Vector2 limits;
    private int direction;
    private Rigidbody2D body;
    private SpriteRenderer sprite;
    private Vector3 originalPosition;

    private void Awake()
    {
        Vector3 pos = transform.localPosition;
        originalPosition = pos;
        limits = new Vector2(pos.x - limitLeft, pos.x + limitRight);

        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        direction = 1; // Hacia la derecha
    }

    // Update is called once per frame
    private void Update()
    {
        if (direction != 0)
        {
            sprite.flipX = direction < 0 ? true : false;
        }
        Vector3 pos = transform.localPosition;
        if (pos.x <= limits.x)
        {
            // Si el enemigo intenta ir hacia la izquierda más allá de lo posible cambiamos de dirección
            direction = 1;
        }
        if (pos.x >= limits.y)
        {
            // Si el enemigo intenta ir hacia la derecha más allá de lo posible cambiamos de dirección
            direction = -1;
        }
        body.linearVelocityX = direction * speedX;
    }

    private void OnDrawGizmos()
    {
        Vector3 pos = originalPosition != Vector3.zero ? originalPosition : transform.localPosition;
        Vector3 posLeft = new Vector3(pos.x - limitLeft, pos.y, pos.z);
        Vector3 posRight = new Vector3(pos.x + limitRight, pos.y, pos.z);
        Gizmos.DrawSphere(posLeft, 0.5f);
        Gizmos.DrawSphere(posRight, 0.5f);
    }
}
