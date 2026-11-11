using System.Collections.Generic;
using LearningProgrammingAcademy.Utils;

namespace LearningProgrammingAcademy.AstroAssault {

    public class PointSpawner : SpawnerBase {

        private IList<SpawnPoint> spawnPoints;
        private Stack<SpawnPoint> pointsToSpawn;

        // == messages ==
        protected override void Start() {            
            spawnPoints = GetComponentsInChildren<SpawnPoint>();           
            ShuffleSpawnPoints();
            base.Start();
        }

        // == private methods ==
        private void ShuffleSpawnPoints() {
            pointsToSpawn = ListUtils.CreateShuffledStack(spawnPoints);
        }

        protected override void Spawn() {
            if (pointsToSpawn.Count == 0) {
                ShuffleSpawnPoints();
            }

            var spawnPoint = pointsToSpawn.Pop();
            
            var enemy = Instantiate(enemyPrefab, enemiesParent.transform);
            // enemy.transform.parent = enemiesParent.transform;
            enemy.transform.position = spawnPoint.transform.position;

            var fallingBehavior = enemy.GetComponent<FallingBehavior>();
            fallingBehavior.Speed = enemyStartSpeed;
        }
    }
}
