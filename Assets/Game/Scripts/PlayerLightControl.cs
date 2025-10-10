using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerLightControl : MonoBehaviour
{
    [SerializeField] private Transform lightTransform;

    private SpriteRenderer sprite;
    private bool isLightFlipped;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        isLightFlipped = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if (sprite.flipX && !isLightFlipped)
        {
            isLightFlipped = true;
            lightTransform.localRotation = Quaternion.Euler(0f, 0f, 90f);
        }
        if (!sprite.flipX && isLightFlipped)
        {
            isLightFlipped = false;
            lightTransform.localRotation = Quaternion.Euler(0f, 0f, -90f);
        }
    }
}
