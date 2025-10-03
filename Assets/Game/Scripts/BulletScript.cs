using UnityEngine;

public class BulletScript : MonoBehaviour
{
    // Valores cambiables en el editor
    [SerializeField] private float speedX;
    [SerializeField] private float speedY;
    [SerializeField] private float maxDistance;

    private Rigidbody2D body;
    private Vector2 initialPosition;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        // La bala se mueve a esa velocidad y no cambiaría porque está configurada como
        // tipo kinemática
        body.linearVelocityX = speedX;
        body.linearVelocityY = speedY;

        Debug.Log("La bala se despierta...");
    }

    public void StartBullet()
    {
        initialPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.localPosition, initialPosition);
        if (distance >= maxDistance)
        {
            // Destruimos el objeto
            Destroy(gameObject);
            Debug.Log("Destruida la bala...");
        }
    }
}
