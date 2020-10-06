using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleDrakeStudios.BehaviorTree {
    public abstract class CompositeNode : BehaviorNode {

        [SerializeField] protected List<BehaviorNode> _behaviorNodes;

        protected Queue<BehaviorNode> _compTree;

        protected BehaviorNode _activeNode;

        public override void Initialize(BehaviorTree behaviorTree) {
            base.Initialize(behaviorTree);
            _activeNode = null;

            _compTree = new Queue<BehaviorNode>();

            for (int i = 0; i < _behaviorNodes.Count; i++) {
                _compTree.Enqueue(_behaviorNodes[i]);
            }
        }
    }
}