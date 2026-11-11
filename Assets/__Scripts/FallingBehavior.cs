using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LearningProgrammingAcademy.AstroAssault {

    [RequireComponent(typeof(Rigidbody2D))]
    public class FallingBehavior : MonoBehaviour {

        // == fields ==        
        private float speed = 2f;
        private Rigidbody2D body;

        // == properties ==
        public float Speed {
            get { return speed; }
            set { speed = value; }
        }

        // == messages ==
        private void Start() {
            body = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate() {
            body.linearVelocity = Vector2.down * speed;
        }
    }
}
