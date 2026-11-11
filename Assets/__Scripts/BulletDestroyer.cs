using UnityEngine;



namespace LearningProgrammingAcademy.AstroAssault
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class BulletDestroyer : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            Bullet bullet = collision.GetComponent<Bullet>();

            if (bullet)
            {
                Destroy(bullet.gameObject);
            }
        }
    }
}