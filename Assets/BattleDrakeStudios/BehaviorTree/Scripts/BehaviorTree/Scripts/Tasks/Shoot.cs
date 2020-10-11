using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleDrakeStudios.BehaviorTree {
    [CreateAssetMenu(fileName = "Shoot", menuName = "BehaviorTree/Task/Shoot")]
    public class Shoot : BehaviorNode {

        public override NodeState Evaluate() {
            GameObject owner = _behaviorTree.BTBoard.GetValue<GameObject>("Owner");
            if (owner.GetComponent<TestAI>().AIBullet != null) {
                Instantiate(owner.GetComponent<TestAI>().AIBullet, owner.transform.position, owner.transform.rotation);
                _nodeState = NodeState.Success;
            } else {
                _nodeState = NodeState.Failed;
            }
            return _nodeState;
        }
    }
}
