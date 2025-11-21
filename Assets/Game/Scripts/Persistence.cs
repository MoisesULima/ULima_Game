using UnityEngine;

public class Persistence : MonoBehaviour
{
    public static string PREFS_CHECKPOINT_NUMBER = "CheckpointNumber";

    private void Awake()
    {
        int checkpoint = PlayerPrefs.GetInt(PREFS_CHECKPOINT_NUMBER, -1);
        // Si no existe ese playerprefs, el valor por defecto es -1
        if (checkpoint == -1) // No existe
        {
            // Lo creamos
            PlayerPrefs.SetInt(PREFS_CHECKPOINT_NUMBER, -1);
        }
        // Si existe no hacemos nada
    }
}
