using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleDrakeStudios.BehaviorTree {
    public abstract class DecoratorNode : BehaviorNode {
        [SerializeField] protected BehaviorNode _childNode;
    }
}