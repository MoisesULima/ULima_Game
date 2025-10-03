using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float timeToShoot;

    private Transform bulletContainerTransform;
    private float timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        timer = 0;
    }

    private void Start()
    {
        GameObject bulletContainer = GameObject.FindGameObjectWithTag("BulletContainer");
        bulletContainerTransform = bulletContainer.transform;
    }

    // Update is called once per frame
    void Update()
    {
        // Sumamos los segundos.
        timer += Time.deltaTime;
        if (timer >= timeToShoot)
        {
            // Creamos el objeto
            GameObject bulletObject = Instantiate(bullet, bulletContainerTransform);
            // Colocamos la posición inicial relativa al enemigo
            bulletObject.transform.localPosition = transform.localPosition;
            // Llamamos al Start del BulletScript para activar la posición de la bala
            BulletScript bulletScript = bulletObject.GetComponent<BulletScript>();
            bulletScript.StartBullet();
            // Reiniciamos el tiempo 
            timer = 0f;
        }
    }
}
