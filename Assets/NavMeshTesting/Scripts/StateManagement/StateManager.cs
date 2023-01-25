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
        ChangeState(new RandomMovementState(GetComponent<NavMeshAgent>()));
    }

    private void ChangeState(State newState) {
        currentState = newState;
        currentState.CorutineRequested += OnCorutineRequested;
    }

    private void OnCorutineRequested(Func<IEnumerator> routine) {
        StartCoroutine(routine());
    }

    // Update is called once per frame
    void Update()
    {
        currentState.DoStep();
    }
}
