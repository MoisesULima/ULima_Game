using UnityEngine;

public class PlayerDetectionHit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Si colisionamos con la zona de muerte "DeadZone" o colisionamos con un enemigo
        if (collision.gameObject.CompareTag("DeadZone") || collision.gameObject.CompareTag("Enemy"))
        {
            SpawnPlayer();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            SpawnPlayer();
            // Desaparecemos la bala
            Destroy(collision.gameObject);
        }
    }

    private void SpawnPlayer()
    {
        // Ubicamos el SpawnPoint, eso significa que el spawnpoint debe tener su etiqueta (tag)
        GameObject spawn = GameObject.FindGameObjectWithTag("SpawnPoint");
        // Mandamos al player a esa posición.
        transform.localPosition = spawn.transform.localPosition;
    }
}
