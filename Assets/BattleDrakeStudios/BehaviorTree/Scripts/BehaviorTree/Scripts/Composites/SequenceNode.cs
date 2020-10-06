using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

namespace BattleDrakeStudios.BehaviorTree {
    [CreateAssetMenu(fileName = "SequenceNode", menuName = "BehaviorTree/Composite/SequenceNode")]
    public class SequenceNode : CompositeNode {

        public override NodeState Evaluate() {
            if (_activeNode == null) {
                if (_compTree.Count > 0) {
                    _activeNode = _compTree.Dequeue();
                    _activeNode.Initialize(_behaviorTree);
                }
            }

            switch (_activeNode.Evaluate()) {
                case NodeState.Running:
                    _nodeState = NodeState.Running;
                    break;

                case NodeState.Failed:
                    _nodeState = NodeState.Failed;
                    return _nodeState;

                case NodeState.Success:
                    if (_compTree.Count > 0) {
                        _activeNode = _compTree.Dequeue();
                        _activeNode.Initialize(_behaviorTree);
                    } else {
                        _activeNode = null;
                        _nodeState = NodeState.Success;
                        return _nodeState;
                    }
                    break;
            }

            return _nodeState;
        }
    }
}