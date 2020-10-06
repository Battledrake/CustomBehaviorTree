using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleDrakeStudios.BehaviorTree {
    [CreateAssetMenu(fileName = "RunWhileTargetFalse", menuName = "BehaviorTree/Decorator/RunWhileTargetFalse")]
    public class RunWhileTargetFalse : DecoratorNode {

        public override void Initialize(BehaviorTree behaviorTree) {
            base.Initialize(behaviorTree);

            if (!_behaviorTree.BTBoard._followTarget) {
                _childNode.Initialize(behaviorTree);
            }
        }

        public override NodeState Evaluate() {
            if (!_behaviorTree.BTBoard._followTarget) {
                _nodeState = _childNode.Evaluate();
            } else {
                _nodeState = NodeState.Failed;
            }
            return _nodeState;
        }
    }
}