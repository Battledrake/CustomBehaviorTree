using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleDrakeStudios.BehaviorTree {
    [CreateAssetMenu(fileName = "RunWhileTargetFalse", menuName = "BehaviorTree/Decorator/RunWhileTargetFalse")]
    public class RunWhileTargetFalse : DecoratorNode {

        private Transform _followTarget;

        public override void Initialize(BehaviorTree behaviorTree) {
            base.Initialize(behaviorTree);

            if (behaviorTree.BTBoard.TryGetValue("FollowTarget", out object obj)) {
                _followTarget = (Transform)obj;
            }
            if (_followTarget == null) {
                _childNode.Initialize(behaviorTree);
            }
        }

        public override NodeState Evaluate() {
            if (_behaviorTree.BTBoard.TryGetValue("FollowTarget", out object obj)) {
                _followTarget = (Transform)obj;
            }
            if (_followTarget == null) {
                _nodeState = _childNode.Evaluate();
            } else {
                _nodeState = NodeState.Failed;
            }
            return _nodeState;
        }
    }
}