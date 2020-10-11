using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleDrakeStudios.BehaviorTree {
    [CreateAssetMenu(fileName = "FindWaypoint", menuName = "BehaviorTree/Task/FindWaypoint")]
    public class FindWaypoints : BehaviorNode {

        public override NodeState Evaluate() {

            Transform wayPointHolder = GameObject.Find("WayPointHolder").transform;
            if (wayPointHolder != null) {
                Transform[] wayPoints = new Transform[wayPointHolder.childCount];
                for (int i = 0; i < wayPointHolder.childCount; i++) {
                    wayPoints[i] = wayPointHolder.GetChild(i);
                }
                _behaviorTree.BTBoard.SetValue("Waypoints", wayPoints);
                _nodeState = NodeState.Success;

            } else {
                _nodeState = NodeState.Failed;
                Debug.LogFormat("{0}: failed to find Waypoints", this.name);
            }
            return _nodeState;
        }
    }
}