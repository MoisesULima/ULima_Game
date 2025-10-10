using UnityEngine;

public class EnemyGrabable : MonoBehaviour
{
    private bool isGrabbed;
    private Transform enemyContainer;
    private CapsuleCollider2D capsuleCollider;
    private Rigidbody2D body;

    private void Awake()
    {
        isGrabbed = false;
        enemyContainer = transform.parent;
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        body = GetComponent<Rigidbody2D>();
    }

    public void ChangeEnemyStatus(Transform grabZone)
    {
        if (!isGrabbed)
        {
            transform.SetParent(grabZone);
            transform.localPosition = Vector3.zero;
            isGrabbed = true;
            capsuleCollider.enabled = false;
            body.simulated = false;
        }
        else
        {
            transform.SetParent(enemyContainer);
            isGrabbed = false;
            capsuleCollider.enabled = true;
            body.simulated = true;
        }
    }
}
