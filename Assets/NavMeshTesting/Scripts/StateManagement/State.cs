using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class State
{
    protected NavMeshAgent characterAgent;

    public State(NavMeshAgent agent) {
        this.characterAgent = agent;
    }

    public abstract void DoStep();

    public abstract State TryToChangeState();

}
