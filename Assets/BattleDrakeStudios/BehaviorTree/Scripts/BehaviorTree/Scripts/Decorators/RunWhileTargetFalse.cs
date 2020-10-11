using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleDrakeStudios.BehaviorTree {
    [CreateAssetMenu(fileName = "RunWhileTargetFalse", menuName = "BehaviorTree/Decorator/RunWhileTargetFalse")]
    public class RunWhileTargetFalse : DecoratorNode {

        public override NodeState Evaluate() {
            Transform followTarget = _behaviorTree.BTBoard.GetValue<Transform>("FollowTarget");

            if (followTarget == null) {
                _nodeState = _childNode.Evaluate();
            } else {
                _nodeState = NodeState.Failed;
            }
            return _nodeState;
        }
    }
}