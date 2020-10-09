using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace BattleDrakeStudios.BehaviorTree {
    [CreateAssetMenu(fileName = "FollowTarget", menuName = "BehaviorTree/Task/FollowTarget")]
    public class FollowTarget : BehaviorNode {

        [SerializeField] private float _idleRange = 0.0f;
        [SerializeField] private float _chaseRange = 0.0f;

        private Transform _followTarget;
        private NavMeshAgent _navAgent;
        private GameObject _owner;

        public override void Initialize(BehaviorTree behaviorTree) {
            base.Initialize(behaviorTree);
            _followTarget = null;
            _navAgent = null;
            _owner = null;

            _navAgent = behaviorTree.NavAgent;
            _owner = behaviorTree.Owner;

            if(behaviorTree.BTBoard.TryGetValue("FollowTarget", out object obj)) {
                _followTarget = (Transform)obj;
            }
        }

        public override NodeState Evaluate() {
            if (_followTarget != null) {
                float distance = Vector3.Distance(_owner.transform.position, _followTarget.position);

                if (distance < _chaseRange) {
                    if (distance > _idleRange) {
                        _navAgent.SetDestination(_followTarget.position);
                        _navAgent.isStopped = false;
                    } else {
                        _navAgent.isStopped = true;
                        _nodeState = NodeState.Success;
                    }
                } else {
                    _behaviorTree.BTBoard["FollowTarget"] = null;
                    _followTarget = null;
                    _navAgent.isStopped = true;
                    _nodeState = NodeState.Failed;
                }
            } else {
                _nodeState = NodeState.Failed;
            }

            return _nodeState;
        }
    }
}