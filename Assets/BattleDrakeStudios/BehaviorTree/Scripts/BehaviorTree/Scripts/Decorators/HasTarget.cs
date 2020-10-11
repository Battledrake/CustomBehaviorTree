using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleDrakeStudios.BehaviorTree {
    [CreateAssetMenu(fileName = "HasTarget", menuName = "BehaviorTree/Decorator/HasTarget")]
    public class HasTarget : DecoratorNode {

        public override NodeState Evaluate() {
            Transform followTarget = null;

            if(_behaviorTree.BTBoard.Contains("FollowTarget")) {
                followTarget = _behaviorTree.BTBoard.GetValue<Transform>("FollowTarget");
            }

            if (followTarget == null) {
                _nodeState = NodeState.Failed;
            }

            if (_nodeState == NodeState.Running) {
                _nodeState = _childNode.Evaluate();
            }

            return _nodeState;
        }
    }
}