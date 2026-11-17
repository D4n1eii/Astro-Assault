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





        public delegate void EnemySpawnedDelegate();

        public static event EnemySpawnedDelegate EnemySpawnedEvent;
        // == messages ==
        protected virtual void Start() {            
            enemiesParent = GameObject.Find(ParentUtils.ENEMIES_PARENT_NAME);
            if (!enemiesParent) {
                Debug.Log($"{ParentUtils.ENEMIES_PARENT_NAME} object not found creating new one");
                enemiesParent = new GameObject(ParentUtils.ENEMIES_PARENT_NAME);
            }

        }

        // == abstract methods ==
        protected abstract void Spawn();

        // == private methods ==
        public void EnableSpawning()
        {
            if (!IsInvoking(SPAWN_METHOD_NAME))
            {
                InvokeRepeating(SPAWN_METHOD_NAME, spawnDelay, spawnInterval);
            }
        }


        public void DisableSpawning()
        {
            Debug.Log($"CANCEL INVOKE: {gameObject.name}");
            CancelInvoke(SPAWN_METHOD_NAME);
        }


        protected void PublishOnEnemySpawnedEvent()
        {
            EnemySpawnedEvent?.Invoke();
        }



    }

}
