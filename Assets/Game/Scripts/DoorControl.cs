using UnityEngine;

public class DoorControl : MonoBehaviour
{
    [SerializeField] private GameObject switchDoor;
    [SerializeField] private GameObject door;

    public void ChangeDoorStatus()
    {
        SpriteRenderer switchSprite = switchDoor.GetComponent<SpriteRenderer>();
        if (door.activeSelf)
        {
            switchSprite.color = Color.red;
            door.SetActive(false);
        }
        else
        {
            switchSprite.color = Color.white;
            door.SetActive(true);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(switchDoor.transform.position, door.transform.position);
    }
}
