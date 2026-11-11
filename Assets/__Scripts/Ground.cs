using UnityEngine;

namespace LearningProgrammingAcademy.AstroAssault
{
    public class Ground : MonoBehaviour
    {
        [SerializeField]
        private GameObject crashExplosionPrefab;

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

                    Destroy(enemy.gameObject);
                }
            }
        }
    }
}