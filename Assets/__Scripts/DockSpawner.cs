using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LearningProgrammingAcademy.Utils;

namespace LearningProgrammingAcademy.AstroAssault {

    public class DockSpawner : SpawnerBase {
              
        [SerializeField]
        [Header("Waypoints")]
        private Transform[] waypoints;

        private IList<Dock> docks;
        private Stack<Dock> docksToSpawn;
      
        // == messages ==
        protected override void Start() {
            docks = GetComponentsInChildren<Dock>();           
            ShuffleDocks();

            base.Start();
        }

        // == private methods ==
        private void ShuffleDocks() {
            docksToSpawn = ListUtils.CreateShuffledStack(docks);
        }
      
        protected override void Spawn() {
            if (docksToSpawn.Count == 0) {
                ShuffleDocks();
            }

            var dock = docksToSpawn.Pop();

            if (dock.IsFull()) {
                dock.Release();
            }

            var slot = dock.NextFreeSlot();

            if (!slot) {
                return;
            }

            var enemy = Instantiate(enemyPrefab, slot.transform);
            enemy.transform.position = transform.position;

            var fallingBehavior = enemy.GetComponent<FallingBehavior>();
            fallingBehavior.Speed = enemyStartSpeed;
            fallingBehavior.enabled = false; // <-- Disable it at spawn so it doesn't fight waypoints

            var follower = enemy.GetComponent<WaypointFollower>();
            // ... rest of your waypoint code ...
            follower.Speed = enemyStartSpeed;
            follower.SetInitialWaypoint(waypoints[0].position);

            foreach (var waypoint in waypoints) {
                follower.AddWaypoint(waypoint.position);
            }


            // add dock entry and slow waypoints
            var dockEntry = dock.GetEntryPoint();
            follower.AddWaypoint(dockEntry);
            follower.AddWaypoint(slot.transform.position);

        }
    }
}
