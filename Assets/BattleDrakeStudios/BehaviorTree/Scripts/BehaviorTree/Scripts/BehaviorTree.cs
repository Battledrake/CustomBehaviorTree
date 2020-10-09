using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;

namespace BattleDrakeStudios.BehaviorTree {
    public enum BTState {
        Running,
        Paused,
        Stopped
    }

    public class BehaviorTree : MonoBehaviour {
        [SerializeField] private BehaviorNode _topNode = null;

        public NavMeshAgent NavAgent => _navAgent;
        public Dictionary<string, object> BTBoard { get => _btBoard; set => _btBoard = value; }
        public GameObject Owner => _owner;

        private Dictionary<string, object> _btBoard;
        private GameObject _owner;
        private NavMeshAgent _navAgent = null;
        private BTState _currentState;


        private void Awake() {
            _owner = this.gameObject;
            _navAgent = this.GetComponent<NavMeshAgent>();
            _currentState = BTState.Stopped;
            _btBoard = new Dictionary<string, object>();
        }

        public void BeginTree() {
            if (_topNode != null) {
                _topNode.Initialize(this);
                _currentState = BTState.Running;
            }
        }

        public void Update() {
            if (_currentState == BTState.Running) {
                if (_topNode.Evaluate() != NodeState.Running) {
                    _topNode.Initialize(this);
                }
            }
        }
    }
}