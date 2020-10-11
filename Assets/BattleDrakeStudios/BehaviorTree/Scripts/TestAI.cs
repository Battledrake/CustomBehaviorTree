using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleDrakeStudios.BehaviorTree {
    public class TestAI : MonoBehaviour {
        [SerializeField] private GameObject _aiBullet = null;

        private BehaviorTree _behaviorTree;

        public GameObject AIBullet => _aiBullet;

        private void Start() {
            _behaviorTree = this.GetComponent<BehaviorTree>();
            
            _behaviorTree.BeginTree();
        }

        private void OnTriggerEnter(Collider other) {
            if (other.CompareTag("Player")) {
                _behaviorTree.BTBoard.SetValue("FollowTarget", other.transform);
            }
        }
    }
}