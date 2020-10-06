using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleDrakeStudios.BehaviorTree {
    [CreateAssetMenu(fileName = "FindWaypoint", menuName = "BehaviorTree/Task/FindWaypoint")]
    public class FindWaypoints : BehaviorNode {

        private BTBlackboard _btBoard;
        private Transform[] _wayPoints;

        public override void Initialize(BehaviorTree behaviorTree) {
            base.Initialize(behaviorTree);

            _btBoard = behaviorTree.BTBoard;
        }

        public override NodeState Evaluate() {

            Transform wayPointHolder = GameObject.Find("WayPointHolder").transform;
            if (wayPointHolder != null) {
                _wayPoints = new Transform[wayPointHolder.childCount];
                for (int i = 0; i < wayPointHolder.childCount; i++) {
                    _wayPoints[i] = wayPointHolder.GetChild(i);
                }
                _btBoard._wayPoints = _wayPoints;
                _nodeState = NodeState.Success;

            } else {
                _nodeState = NodeState.Failed;
            }
            return _nodeState;
        }
    }
}