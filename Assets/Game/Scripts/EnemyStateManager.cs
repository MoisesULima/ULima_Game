using UnityEngine;

public class EnemyStateManager : MonoBehaviour
{
    // Vamos a tener referencias de los estados del enemigo
    public enum State
    {
        None,
        Idle,
        Chase,
        Shoot,
        Dead
    }

    private State state;
    private EnemyIdleState idleState;

    private void Awake()
    {
        state = State.None;
        // Esto me va a guardar el estado de idle, pero si no lo he agregado guardaría un objeto "null"
        idleState = GetComponent<EnemyIdleState>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        if (idleState != null)
            state = State.Idle;
    }

    // Update is called once per frame
    private void Update()
    {
        // Acá vamos a hacer el manejo de los estados, para que se llame a su Update
        switch(state)
        {
            case State.Idle:
                idleState.UpdateState();
                break;
        }
    }

    public void ChangeState(State newState)
    {
        state = newState;
    }
}
