using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class EnemyIdleState : MonoBehaviour
{
    [SerializeField] private Vector2 areaDetection;

    private bool playerDetected;
    private Transform playerTransform;

    private void Awake()
    {
        playerDetected = false;
    }

    private void Start()
    {
        // El enemigo sabe donde está el player en todo momento
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void OnDrawGizmos()
    {
        //Gizmos.DrawCube(transform.localPosition, new Vector3(areaDetection.x, areaDetection.y, 1));

    }

    private void Update()
    {
        if (playerDetected)
            return;
        float leftX = transform.localPosition.x - areaDetection.x;
        float rightX = transform.localPosition.x + areaDetection.x;
        float downY = transform.localPosition.y - areaDetection.y;
        float upY = transform.localPosition.y + areaDetection.y;
        float playerX = playerTransform.localPosition.x;
        float playerY = playerTransform.localPosition.y;
        if (playerX >= leftX && playerX <= rightX && playerY >= downY && playerY <= upY)
        {
            Debug.Log("Player Detectado...");
            playerDetected = true;
        }
    }
}
