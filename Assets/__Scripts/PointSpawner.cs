using System.Collections.Generic;
using UnityEngine;

namespace LearningProgramAcademy.AstroAssault
{
    public class PointSpawner : MonoBehaviour
    {

        // == constants ==
        private const string SPAWN_METHOD_NAME = "Spawn";


        [SerializeField]
        private GameObject enemyPrefab;

        [SerializeField]

        private float spawnInterval = 1.6f;

        [SerializeField]

        private float spawnDelay = 0.2f;

        [SerializeField]

        private float enemyStartSpeed;


        private IList<SpawnPoint> spawnPoints;


        private void Start()
        {
            spawnPoints = GetComponentsInChildren<SpawnPoint>();
        }


        // == private methods ==

        private void SpawnRepeating()
        {
            InvokeRepeating(SPAWN_METHOD_NAME, spawnDelay, spawnInterval);
        }

        private void Spawn()
        {
            var randomIndex = Random.Range(0, spawnPoints.Count);
            var spawnPoint = spawnPoints[randomIndex];

            var enemy = Instantiate(enemyPrefab);

            enemy.transform.position = spawnPoint.transform.position;
        }

    }
}