using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleDrakeStudios.BehaviorTree {
    [CreateAssetMenu(fileName = "LookAt", menuName = "BehaviorTree/Task/LookAt")]
    public class LookAtTarget : BehaviorNode {

        public override NodeState Evaluate() {
            Transform followTarget = _behaviorTree.BTBoard.GetValue<Transform>("FollowTarget");
            GameObject owner = _behaviorTree.BTBoard.GetValue<GameObject>("Owner");

            if (followTarget != null) {
                owner.transform.LookAt(followTarget);
                _nodeState = NodeState.Success;
            } else {
                _nodeState = NodeState.Failed;
            }

            return _nodeState;
        }
    }
}