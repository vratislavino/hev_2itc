using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class State
{
    protected NavMeshAgent characterAgent;
    protected StaticSymbol symbol;

    public State(NavMeshAgent agent, StaticSymbol symbol) {
        this.characterAgent = agent;
        this.symbol = symbol;
    }

    public abstract void DoStep();

    public abstract State TryToChangeState();

}
