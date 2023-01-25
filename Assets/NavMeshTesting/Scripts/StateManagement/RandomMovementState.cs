using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomMovementState : State
{
    Vector3 targetPoint;
    float minDistance = 3f;

    Vector3 lastPosition;
    Quaternion lastRotation;

    public RandomMovementState(NavMeshAgent agent) : base(agent) {
        targetPoint = GenerateRandomPoint();
        characterAgent.SetDestination(targetPoint);
    }

    public override void DoStep() {
        Vector3 playerCheckPosition = new Vector3(characterAgent.transform.position.x, 0, characterAgent.transform.position.z);

        if (Vector3.Distance(playerCheckPosition, targetPoint) < minDistance) {
            targetPoint = GenerateRandomPoint();
            characterAgent.SetDestination(targetPoint);
        }
        // zkontrolovat pohyb
        if(Vector3.Distance(characterAgent.transform.position, lastPosition) < 0.000001 
            && Quaternion.Angle(characterAgent.transform.rotation, lastRotation) < 0.1f) {
            targetPoint = GenerateRandomPoint();
            characterAgent.SetDestination(targetPoint);
        }

        // pøiøadit aktuální data do last data
        lastPosition = characterAgent.transform.position;
        lastRotation = characterAgent.transform.rotation;
    }

    private Vector3 GenerateRandomPoint() {
        return new Vector3(Random.Range(0, 100), 0, Random.Range(0, 100));
    }

    public override State TryToChangeState() {
        // try to change state based on player position
        return null;
    }
}
