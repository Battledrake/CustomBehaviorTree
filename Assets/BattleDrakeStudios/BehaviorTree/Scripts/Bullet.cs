using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleDrakeStudios.BehaviorTree {
    public class Bullet : MonoBehaviour {

        [SerializeField] private float _moveSpeed = 0.0f;

        private void Update() {
            transform.Translate(transform.forward * _moveSpeed * Time.deltaTime, Space.World);
            Destroy(this.gameObject, 5.0f);
        }

    }
}