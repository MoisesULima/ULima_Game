using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDetectionHit : MonoBehaviour
{
    private int lives;
    private Animator animator;

    private void Awake()
    {
        lives = 5;
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Si colisionamos con la zona de muerte "DeadZone" o colisionamos con un enemigo
        if (collision.gameObject.CompareTag("Enemy"))
        {
            DecreaseLife();
        }
        if ( collision.gameObject.CompareTag("DeadZone"))
        {
            SpawnPlayer();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            DecreaseLife();
            // Desaparecemos la bala
            Destroy(collision.gameObject);
        }
    }

    private void DecreaseLife()
    {
        // Reduce la vida en 1
        lives--;
        if (lives == 0)
        {
            // Spawneamos con nueva vida 
            SpawnPlayer();
        }
        else
        {
            // Tenemos que activar un Hit
            animator.SetTrigger("PlayerHit");
            animator.SetBool("isHit", true);
        }
    }

    public void FinishHit()
    {
        animator.SetBool("isHit", false);
    }
    
    private void SpawnPlayer()
    {
        /*
        lives = 5;
        // Ubicamos el SpawnPoint, eso significa que el spawnpoint debe tener su etiqueta (tag)
        GameObject spawn = GameObject.FindGameObjectWithTag("SpawnPoint");
        // Mandamos al player a esa posici�n.
        transform.localPosition = spawn.transform.localPosition;
        */
        SceneManager.LoadScene("EjemploPlatformer");
    }
}
