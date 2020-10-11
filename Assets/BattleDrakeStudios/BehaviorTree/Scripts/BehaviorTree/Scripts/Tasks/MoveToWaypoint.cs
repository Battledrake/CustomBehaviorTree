using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace BattleDrakeStudios.BehaviorTree {
    [CreateAssetMenu(fileName = "MoveToWayPoint", menuName = "BehaviorTree/Task/MoveToWayPoint")]
    public class MoveToWaypoint : BehaviorNode {

        private Vector3 _destination;

        public override void Initialize(BehaviorTree behaviorTree) {
            base.Initialize(behaviorTree);
            _destination = Vector3.zero;


            GameObject owner = _behaviorTree.BTBoard.GetValue<GameObject>("Owner");
            NavMeshAgent navAgent = _behaviorTree.BTBoard.GetValue<NavMeshAgent>("NavAgent");

            //TODO:Rework this node to move everything to Evaluate if possible. Reducing Initialize needs(if it is better solution(might not be!))

            Transform[] wayPoints = _behaviorTree.BTBoard.GetValue<Transform[]>("Waypoints");
            if (wayPoints != null && wayPoints.Length > 0) {
                Transform randomDest = wayPoints[Random.Range(0, wayPoints.Length)];

                float distance = Vector3.Distance(owner.transform.position, randomDest.position);

                while (distance <= 5) {
                    randomDest = wayPoints[Random.Range(0, wayPoints.Length)];
                    distance = Vector3.Distance(owner.transform.position, randomDest.position);
                }
                _destination = randomDest.position;
                navAgent.SetDestination(randomDest.position);
                navAgent.isStopped = false;

            } else {
                _nodeState = NodeState.Failed;
            }
        }

        public override NodeState Evaluate() {
            if(_nodeState != NodeState.Failed) {
                GameObject owner = _behaviorTree.BTBoard.GetValue<GameObject>("Owner");
                NavMeshAgent navAgent = _behaviorTree.BTBoard.GetValue<NavMeshAgent>("NavAgent");

                float distance = Vector3.Distance(owner.transform.position, _destination);

                if (distance <= 2) {
                    navAgent.isStopped = true;
                    _nodeState = NodeState.Success;
                } else {
                    _nodeState = NodeState.Running;
                }
            }
            return _nodeState;
        }
    }
}