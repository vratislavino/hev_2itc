using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomMovementState : State
{

    Vector3 targetPoint;
    float minDistance = 0.5f;
    bool foundFirst = false;

    public RandomMovementState(NavMeshAgent agent) : base(agent) {
        //targetPoint = GenerateRandomPoint(); TODO :)
    }

    public override void DoStep() {
        if (Vector3.Distance(characterAgent.transform.position, targetPoint) < minDistance || !foundFirst) {
            foundFirst= true;
            RaiseCorutineRequested(SetDestinationRoutine);
        }
    }

    private IEnumerator SetDestinationRoutine() {
        while (true) {
            Debug.Log("HLEDAM");
            var newPos = new Vector3(Random.Range(0, 100), 0, Random.Range(0, 100));
            characterAgent.SetDestination(newPos);
            while (characterAgent.pathPending) {
                yield return null;
            }
            if (characterAgent.pathStatus == NavMeshPathStatus.PathComplete) {
                // nastavená správná pozice, mùže jít
                targetPoint = newPos;
                break;
            } else {
                // najdi nový point, tenhle se nepovedl
                yield return null;
            }
        }
    }

    public override State TryToChangeState() {
        return null;
    }
}
