using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleDrakeStudios.BehaviorTree {
    [CreateAssetMenu(fileName = "Shoot", menuName = "BehaviorTree/Task/Shoot")]
    public class Shoot : BehaviorNode {
        private GameObject _owner;

        public override void Initialize(BehaviorTree behaviorTree) {
            base.Initialize(behaviorTree);

            _owner = behaviorTree.Owner;
        }

        public override NodeState Evaluate() {
            if (_owner.GetComponent<TestAI>().AIBullet != null) {
                Instantiate(_owner.GetComponent<TestAI>().AIBullet, _owner.transform.position, _owner.transform.rotation);
                _nodeState = NodeState.Success;
            } else {
                _nodeState = NodeState.Failed;
            }
            return _nodeState;
        }
    }
}
