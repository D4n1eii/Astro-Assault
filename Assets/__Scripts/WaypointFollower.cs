using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace LearningProgrammingAcademy.AstroAssault {

    [RequireComponent(typeof(Rigidbody2D))]
    public class WaypointFollower : MonoBehaviour {

        // == fields ==
        private IList<Vector3> waypoints = new List<Vector3>();
        private Vector3 currentWaypoint;
        private float speed;

        private Rigidbody2D body;


        // == properties ==
        public float Speed {
            get { return speed; }
            set { speed = value; }
        }

        // == messages ==
        private void Start()
        {
            body = GetComponent<Rigidbody2D>();


            NextWaypoint();
        }
        public void SetInitialWaypoint(Vector3 point)
        {
            waypoints.Insert(0, point);
        }
        private void FixedUpdate() {
            if (HasMorePoints()) {
                Move();
            }
        }

        // == public methods ==
        public void AddWaypoint(Vector3 point) {
            waypoints.Add(point);
        }

        // == private methods ==
        private void NextWaypoint() {
            if (HasMorePoints()) {
                currentWaypoint = waypoints.First();
            }
        }

        private bool HasMorePoints() {
            return waypoints.Count != 0;
        }

        private void Move() {
            body.position = Vector3.MoveTowards(body.position, currentWaypoint, Time.deltaTime * speed);

            if (Vector3.Distance(body.position, currentWaypoint) < 0.001f) {
                body.position = new Vector2(currentWaypoint.x, currentWaypoint.y);
                waypoints.Remove(currentWaypoint);

                if (HasMorePoints()) {
                    NextWaypoint();
                }
            }
        }
    }
}