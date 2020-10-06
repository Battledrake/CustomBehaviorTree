using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleDrakeStudios.BehaviorTree {
    [CreateAssetMenu(fileName = "HasTarget", menuName = "BehaviorTree/Decorator/HasTarget")]
    public class HasTarget : DecoratorNode {

        public override void Initialize(BehaviorTree behaviorTree) {
            base.Initialize(behaviorTree);

            if (_behaviorTree.BTBoard._followTarget != null) {
                _nodeState = NodeState.Running;
                _childNode.Initialize(behaviorTree);
            }
        }
        public override NodeState Evaluate() {
            if (_behaviorTree.BTBoard._followTarget == null) {
                _nodeState = NodeState.Failed;
            }

            if (_nodeState == NodeState.Running) {
                _nodeState = _childNode.Evaluate();
            }

            return _nodeState;
        }
    }
}