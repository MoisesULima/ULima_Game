using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private List<Checkpoint> checkpointList;

    private void Start()
    {
        for(int i = 0; i < checkpointList.Count; i++)
        {
            checkpointList[i].Init(this, i);
        }
    }

    public void ChangeActivation(int idActivated)
    {
        for(int i = 0; i < checkpointList.Count; i++)
        {
            if (i != idActivated)
            {
                checkpointList[i].Deactivate();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
