using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class State
{
    public event Action<Func<IEnumerator>> CorutineRequested;

    protected NavMeshAgent characterAgent;

    public State(NavMeshAgent agent) {
        this.characterAgent = agent;
    }

    public void RaiseCorutineRequested(Func<IEnumerator> routine) {
        CorutineRequested?.Invoke(routine);
    }

    public abstract void DoStep();

    public abstract State TryToChangeState();

}
