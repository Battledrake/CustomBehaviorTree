using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace BattleDrakeStudios.BehaviorTree {
    [CreateAssetMenu(fileName = "MoveToWayPoint", menuName = "BehaviorTree/Task/MoveToWayPoint")]
    public class MoveToWaypoint : BehaviorNode {

        private NavMeshAgent _navAgent;
        private BTBlackboard _btBoard;
        private Transform _destination;
        private GameObject _owner;

        public override void Initialize(BehaviorTree behaviorTree) {
            base.Initialize(behaviorTree);

            _btBoard = behaviorTree.BTBoard;
            _navAgent = behaviorTree.NavAgent;
            _owner = behaviorTree.Owner;
            _destination = null;

            if (_btBoard._wayPoints.Length > 0) {
                Transform randomDest = _btBoard._wayPoints[Random.Range(0, _btBoard._wayPoints.Length)];

                float distance = Vector3.Distance(_owner.transform.position, randomDest.position);

                while (distance <= 5) {
                    randomDest = _btBoard._wayPoints[Random.Range(0, _btBoard._wayPoints.Length)];
                    distance = Vector3.Distance(_owner.transform.position, randomDest.position);
                }

                _destination = randomDest;
                _navAgent.SetDestination(_destination.position);
                _navAgent.isStopped = false;
            } else {
                _nodeState = NodeState.Failed;
            }
        }

        public override NodeState Evaluate() {
            if (_destination != null) {
                float distance = Vector3.Distance(_owner.transform.position, _destination.position);

                if (distance <= 2) {
                    _navAgent.isStopped = true;
                    _nodeState = NodeState.Success;
                } else {
                    _nodeState = NodeState.Running;
                }
            }
            return _nodeState;
        }
    }
}