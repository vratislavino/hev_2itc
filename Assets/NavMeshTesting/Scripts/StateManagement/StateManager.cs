using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class StateManager : MonoBehaviour
{
    private State currentState;

    // Start is called before the first frame update
    void Start()
    {
        var agent = GetComponent<NavMeshAgent>();
        var symbol = GetComponent<StaticSymbol>();

        ChangeState(
            new RandomMovementState(agent, symbol)
            );
    }

    private void ChangeState(State newState) {
        currentState = newState;
    }

    // Update is called once per frame
    void Update()
    {
        currentState.DoStep();
        var newState = currentState.TryToChangeState();
        if(newState != null) {
            ChangeState(newState);
        }
    }
}
