using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace LearningProgrammingAcademy.AstroAssault
{
    [RequireComponent(typeof(Animator))]
    public class MotherShipController : MonoBehaviour
    {


        private const string NEXT_WAVE_TRIGGER_NAME = "NextWave";

        private SpawnerBase[] spawners;



        [SerializeField] private int enemyCountPerWave = 20;


        [SerializeField] private int remainingEnemyCount;

        [SerializeField] private int waveNumber = 0;

        [SerializeField]
        private TextMeshProUGUI waveNumberText;



        [SerializeField]
        private TextMeshProUGUI remainingEnemyCountText;

        private Animator animator;


        [SerializeField]
        private AudioClip movingClip;


        [SerializeField]
        private AudioClip idleClip;


        private SoundController soundController;




        private void Start()
        {
            spawners = FindObjectsByType<SpawnerBase>();
            animator = GetComponent<Animator>();
            remainingEnemyCount = enemyCountPerWave;
            soundController = SoundController.FindSoundController();
            soundController?.Play(movingClip);

        }

        private void AnimatorEnableSpawn()
        {
            if (remainingEnemyCount <= 0)
                return;

            EnableSpawn();
        }


        private void OnEnable()
        {
            SpawnerBase.EnemySpawnedEvent += OnEnemySpawned;
        }

        private void OnDisable()
        {
            SpawnerBase.EnemySpawnedEvent -= OnEnemySpawned;

        }






        private void DisableSpawning()
        {

            foreach (var spawner in spawners)
            {
                spawner.DisableSpawning();
            }
        }



        private void UpdateText()
        {
            waveNumberText.text = waveNumber.ToString("000");
            remainingEnemyCountText.text = remainingEnemyCount.ToString("000");
        }
        private void OnEnemySpawned()
        {


            if (remainingEnemyCount <= 0)
                return;

            remainingEnemyCount--;
            UpdateText();


            if (remainingEnemyCount == 0)
            {
                DisableSpawning();
                animator.SetTrigger(NEXT_WAVE_TRIGGER_NAME);
                soundController?.Play(movingClip);
            }
        }

        private void NextWave()
        {
            waveNumber++;
            remainingEnemyCount = enemyCountPerWave;
            UpdateText();
        }
        public void StartWave()
        {
            NextWave();
            EnableSpawn();

        }

        private void EnableSpawn()
        {
            foreach (var spawner in spawners)
            {
                spawner.EnableSpawning();
            }
        }


    }
}