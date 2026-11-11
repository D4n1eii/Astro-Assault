using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LearningProgrammingAcademy.AstroAssault.Utils;

namespace LearningProgrammingAcademy.AstroAssault {

    public abstract class SpawnerBase : MonoBehaviour {

        // == constants ==
        private const string SPAWN_METHOD_NAME = "Spawn";

        // == fields ==
        [SerializeField]
        protected Enemy enemyPrefab;

        [SerializeField]
        protected float spawnInterval = 1.6f;

        [SerializeField]
        protected float spawnDelay = 0.2f;

        [SerializeField]
        protected float enemyStartSpeed = 2f;

        protected GameObject enemiesParent;

        // == messages ==
        protected virtual void Start() {            
            enemiesParent = GameObject.Find(ParentNames.ENEMIES_PARENT_NAME);

            if (!enemiesParent) {
                Debug.Log($"{ParentNames.ENEMIES_PARENT_NAME} object not found creating new one");
                enemiesParent = new GameObject(ParentNames.ENEMIES_PARENT_NAME);
            }
            
            SpawnRepeating();
        }

        // == abstract methods ==
        protected abstract void Spawn();

        // == private methods ==
        private void SpawnRepeating() {
            InvokeRepeating(SPAWN_METHOD_NAME, spawnDelay, spawnInterval);
        }
    }

}
