using UnityEngine;
using UnityEngine.U2D;

public class BulletScript : MonoBehaviour
{
    // Valores cambiables en el editor
    [SerializeField] private float speedX;
    [SerializeField] private float speedY;
    [SerializeField] private float maxDistance;
    [SerializeField] private float fade = 1f;

    private Rigidbody2D body;
    private SpriteRenderer sprite;
    private Vector2 initialPosition;
    private bool isDisappearing;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        // La bala se mueve a esa velocidad y no cambiaría porque está configurada como
        // tipo kinemática
        body.linearVelocityX = speedX;
        body.linearVelocityY = speedY;

        isDisappearing = false;
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
            isDisappearing = true;
        }

        if (isDisappearing)
        {
            fade -= Time.deltaTime;
            if (fade <= 0f)
            {
                fade = 0f;
                // Destruimos el objeto
                Destroy(gameObject);
            }
            sprite.material.SetFloat("_Fade", fade);
        }
    }
}
