using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Animator animator;
    private CheckpointManager manager;
    private int id;
    private bool isActive;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        isActive = false;
    }

    public void Init(CheckpointManager manager, int id)
    {
        this.manager = manager;
        this.id = id;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isActive)
        {
            animator.SetTrigger("Activate");
            isActive = true;
            manager.ChangeActivation(id);
        }
    }

    public void Deactivate()
    {
        if (isActive)
        {
            animator.SetTrigger("Deactivate");
            isActive = false;
        }
    }
}
