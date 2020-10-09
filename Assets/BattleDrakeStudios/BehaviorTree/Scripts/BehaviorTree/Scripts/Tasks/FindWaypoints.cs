using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleDrakeStudios.BehaviorTree {
    [CreateAssetMenu(fileName = "FindWaypoint", menuName = "BehaviorTree/Task/FindWaypoint")]
    public class FindWaypoints : BehaviorNode {

        private Transform[] _wayPoints;

        public override void Initialize(BehaviorTree behaviorTree) {
            base.Initialize(behaviorTree);
            _wayPoints = null;
        }

        public override NodeState Evaluate() {

            Transform wayPointHolder = GameObject.Find("WayPointHolder").transform;
            if (wayPointHolder != null) {
                _wayPoints = new Transform[wayPointHolder.childCount];
                for (int i = 0; i < wayPointHolder.childCount; i++) {
                    _wayPoints[i] = wayPointHolder.GetChild(i);
                }
                _behaviorTree.BTBoard["Waypoints"] = _wayPoints;
                _nodeState = NodeState.Success;

            } else {
                _nodeState = NodeState.Failed;
                Debug.LogFormat("{0}: failed to find Waypoints", this.name);
            }
            return _nodeState;
        }
    }
}