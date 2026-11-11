using System;
using UnityEngine;
using TMPro; // 1. Add the TextMeshPro namespace

namespace LearningProgrammingAcademy.AstroAssault
{
    public class GameController : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI scoreText; // 2. Change type to TextMeshProUGUI
        private int score = 0;

        private void OnEnable()
        {
            Enemy.EnemyKilledEvent += OnEnemyKilled;
        }

        private void OnEnemyKilled(Enemy enemy)
        {
            score += enemy.ScoreValue;
            UpdateLabels();
        }

        private void OnDisable()
        {
            Enemy.EnemyKilledEvent -= OnEnemyKilled;
        }

        private void UpdateLabels()
        {
            scoreText.text = score.ToString("000000"); 
        }
    }
}