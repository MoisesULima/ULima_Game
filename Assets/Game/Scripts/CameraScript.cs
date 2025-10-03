using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private GameObject playerReference;
    private Vector2 playerPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        playerReference = GameObject.FindGameObjectWithTag("Player");
        Debug.Log(playerReference.transform.position);
        Vector2 player = playerReference.transform.localPosition;
        playerPos = new Vector2(player.x, player.y);
    }

    // Update is called once per frame
    private void Update()
    {
        // Calculamos la posición actual del player, y la restamos con la anterior
        // Para saber cuánto se ha movido con respecto al último frame
        // Esa distancia que se ha movido debe moverse nuestra cámara.
        Vector2 player = playerReference.transform.localPosition;
        float deltaX = player.x - playerPos.x;
        float deltaY = player.y - playerPos.y;
        playerPos = new Vector2(player.x, player.y);

        Vector3 cameraPos = transform.localPosition;
        transform.localPosition = new Vector3(cameraPos.x + deltaX, cameraPos.y + deltaY, cameraPos.z);
    }
}
