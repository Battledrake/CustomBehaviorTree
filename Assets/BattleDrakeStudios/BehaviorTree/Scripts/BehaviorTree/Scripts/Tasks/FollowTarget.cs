using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace BattleDrakeStudios.BehaviorTree {
    [CreateAssetMenu(fileName = "FollowTarget", menuName = "BehaviorTree/Task/FollowTarget")]
    public class FollowTarget : BehaviorNode {

        [SerializeField] private float _idleRange = 0.0f;
        [SerializeField] private float _chaseRange = 0.0f;

        public override NodeState Evaluate() {
            Transform followTarget = _behaviorTree.BTBoard.GetValue<Transform>("FollowTarget");
            NavMeshAgent navAgent = _behaviorTree.BTBoard.GetValue<NavMeshAgent>("NavAgent");
            GameObject owner = _behaviorTree.BTBoard.GetValue<GameObject>("Owner");

            if (followTarget != null) {
                float distance = Vector3.Distance(owner.transform.position, followTarget.position);

                if (distance < _chaseRange) {
                    if (distance > _idleRange) {
                        navAgent.SetDestination(followTarget.position);
                        navAgent.isStopped = false;
                    } else {
                        navAgent.isStopped = true;
                        _nodeState = NodeState.Success;
                    }
                } else {
                    _behaviorTree.BTBoard.SetValue("FollowTarget", null);
                    navAgent.isStopped = true;
                    _nodeState = NodeState.Failed;
                }
            } else {
                _nodeState = NodeState.Failed;
            }

            return _nodeState;
        }
    }
}