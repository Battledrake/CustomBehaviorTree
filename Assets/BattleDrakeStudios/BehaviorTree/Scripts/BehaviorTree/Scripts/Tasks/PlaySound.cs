using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleDrakeStudios.BehaviorTree {
    [CreateAssetMenu(fileName = "PlaySound", menuName = "BehaviorTree/Task/PlaySound")]
    public class PlaySound : BehaviorNode {
        [SerializeField] private AudioClip _audioClip = null;
        public override NodeState Evaluate() {
            if (_audioClip != null) {
                AudioSource.PlayClipAtPoint(_audioClip, _behaviorTree.Owner.transform.position);
                _nodeState = NodeState.Success;
            } else {
                _nodeState = NodeState.Failed;
                Debug.LogWarning("No audio clip found");
            }
            return _nodeState;
        }
    }
}
