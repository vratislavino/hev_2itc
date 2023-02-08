using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FightMovementState : State
{
    public FightMovementState(NavMeshAgent agent, StaticSymbol symbol) : base(agent, symbol) {
    }

    public override void DoStep() {
        bool wouldEnemyWin = GameManager.Instance.PlayerReference.WouldEnemyWin(symbol.CurrentSymbol);
        if(wouldEnemyWin) {
            characterAgent.SetDestination(GameManager.Instance.PlayerReference.transform.position);
        } else {
            var dir = GameManager.Instance.PlayerReference.transform.position - characterAgent.transform.position;
            dir.y = 0;
            characterAgent.SetDestination(characterAgent.transform.position - dir);
        }
    }

    public override State TryToChangeState() {
        if (Vector3.Distance(
            characterAgent.transform.position,
            GameManager.Instance.PlayerReference.transform.position
            ) < 10) {
            if (symbol.CurrentSymbol != GameManager.Instance.PlayerReference.CurrentSymbol)
                return null;
            return new RandomMovementState(characterAgent, symbol);
        }

        return new RandomMovementState(characterAgent, symbol);
    }
}
