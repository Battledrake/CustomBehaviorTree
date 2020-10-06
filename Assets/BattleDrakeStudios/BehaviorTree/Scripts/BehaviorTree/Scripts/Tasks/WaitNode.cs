using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

namespace BattleDrakeStudios.BehaviorTree {
    [CreateAssetMenu(fileName = "WaitNode", menuName = "BehaviorTree/Task/WaitNode")]
    public class WaitNode : BehaviorNode {
        [SerializeField] private float _waitTime = 0.0f;

        private float _timer;

        public override void Initialize(BehaviorTree behaviorTree) {
            _timer = _waitTime;
        }

        public override NodeState Evaluate() {
            if (_timer > 0.0f) {
                _timer -= Time.deltaTime;
            } else {
                _nodeState = NodeState.Success;
                return _nodeState;
            }
            _nodeState = NodeState.Running;
            return _nodeState;
        }
    }
}