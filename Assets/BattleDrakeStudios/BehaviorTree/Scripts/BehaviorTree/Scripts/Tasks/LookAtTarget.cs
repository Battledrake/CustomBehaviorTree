﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleDrakeStudios.BehaviorTree {
    [CreateAssetMenu(fileName = "LookAt", menuName = "BehaviorTree/Task/LookAt")]
    public class LookAtTarget : BehaviorNode {
        private Transform _followTarget;
        private GameObject _owner;

        public override void Initialize(BehaviorTree behaviorTree) {
            base.Initialize(behaviorTree);

            _followTarget = behaviorTree.BTBoard._followTarget;
            _owner = behaviorTree.Owner;
        }

        public override NodeState Evaluate() {
            if (_followTarget != null) {
                _owner.transform.LookAt(_followTarget);
                _nodeState = NodeState.Success;
            } else {
                _nodeState = NodeState.Failed;
            }

            return _nodeState;
        }
    }
}