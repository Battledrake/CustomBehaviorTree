using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleDrakeStudios.BehaviorTree {
    public enum NodeState {
        Running,
        Success,
        Failed
    }

    public abstract class BehaviorNode : ScriptableObject {

        protected NodeState _nodeState;
        protected BehaviorTree _behaviorTree;

        public NodeState NodeState => _nodeState;

        public virtual void Initialize(BehaviorTree behaviorTree) {
            _behaviorTree = behaviorTree;

            _nodeState = NodeState.Running;
        }
        public abstract NodeState Evaluate();
    }
}