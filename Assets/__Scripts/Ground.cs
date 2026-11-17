using System;
using TMPro;
using UnityEngine;

namespace LearningProgrammingAcademy.AstroAssault
{
    public class Ground : MonoBehaviour
    {
        [SerializeField]
        private GameObject crashExplosionPrefab;

        [SerializeField]
        private TextMeshProUGUI textScore;

        [SerializeField]
        private SoundController soundController;

        private void OnTriggerEnter2D(Collider2D collider)
        {
            var enemy = collider.GetComponent<Enemy>();
            if (enemy != null)
            {
                // Optional safety check: only explode if it's actively falling
                var fallingBehavior = enemy.GetComponent<FallingBehavior>();
                if (fallingBehavior == null || fallingBehavior.enabled)
                {
                    if (crashExplosionPrefab != null)
                    {
                        Instantiate(crashExplosionPrefab, enemy.transform.position, Quaternion.identity);
                    }
                    soundController.PlayOneShot(enemy.crashClip);
                    Destroy(enemy.gameObject);
                    int score = Int32.Parse(textScore.text);
                    score -= enemy.ScoreValue;
                    string newScore = score.ToString("000000 ");
                    textScore.text = newScore;
                }
            }
        }
    }
}