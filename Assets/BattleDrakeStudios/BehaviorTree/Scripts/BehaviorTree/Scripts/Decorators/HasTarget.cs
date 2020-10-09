using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleDrakeStudios.BehaviorTree {
    [CreateAssetMenu(fileName = "HasTarget", menuName = "BehaviorTree/Decorator/HasTarget")]
    public class HasTarget : DecoratorNode {

        private Transform _followTarget;

        public override void Initialize(BehaviorTree behaviorTree) {
            base.Initialize(behaviorTree);
            _followTarget = null;

            if(behaviorTree.BTBoard.TryGetValue("FollowTarget", out object obj)) {
                _followTarget = (Transform)obj;
                if(_followTarget != null) {
                    _childNode.Initialize(behaviorTree);
                }
            }
        }
        public override NodeState Evaluate() {
            if (_followTarget == null) {
                _nodeState = NodeState.Failed;
            }

            if (_nodeState == NodeState.Running) {
                _nodeState = _childNode.Evaluate();
            }

            return _nodeState;
        }
    }
}