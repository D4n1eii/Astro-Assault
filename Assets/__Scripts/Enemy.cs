using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LearningProgrammingAcademy.AstroAssault.Utils;

namespace LearningProgrammingAcademy.AstroAssault {

    public class Enemy : MonoBehaviour {

        [SerializeField]
        private GameObject hitExplosionPrefab;

        [SerializeField]    
        private GameObject crashExplosionPrefab;

        [SerializeField]
        private int scoreValue = 10;


        public int ScoreValue
        {
            get { return scoreValue; }
            set { value = scoreValue; }
        }




        public delegate void EnemyKilled(Enemy enemy);



        public static event EnemyKilled EnemyKilledEvent;

        private GameObject explosionParent;
        private void OnTriggerEnter2D(Collider2D collider)
        {
            var bullet = collider.GetComponent<Bullet>();
            if (bullet)
            {
                PublishEnemyKilledEvent();
                SpawnExplosion(hitExplosionPrefab);
                Destroy(bullet.gameObject);
                Destroy(gameObject);
            }

            var player = collider.GetComponent<Player>();
            if (player)
            {
                player.Die();
                SpawnExplosion(hitExplosionPrefab);
                Destroy(gameObject);
            }
           
        }


        private void Start()
        {
            explosionParent = GameObject.Find(ParentNames.EXPLOSIONS_PARENT_NAME);

            if (!explosionParent)
            {
                explosionParent = new GameObject(ParentNames.EXPLOSIONS_PARENT_NAME);  
            }
        }


        private void SpawnExplosion(GameObject explosionPrefab)
        
        {
            GameObject explosionGameObject = Instantiate(explosionPrefab, explosionParent.transform);
            explosionGameObject.transform.position = transform.position;
        }



        private void PublishEnemyKilledEvent()
        {
            EnemyKilledEvent?.Invoke(this);
        }


    }
}
