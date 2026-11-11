using LearningProgrammingAcademy.AstroAssault.Utils;
using System.Collections;
using UnityEngine;
namespace LearningProgrammingAcademy.AstroAssault
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(PolygonCollider2D))]
    [RequireComponent(typeof(PlayerController))]
    [RequireComponent(typeof(WeaponController))]

    public class Player : MonoBehaviour
    {
        [SerializeField]
        private int lives = 4;

        [SerializeField]
        private GameObject explosionPrefab;



        private SpriteRenderer spriteRenderer;

        private PolygonCollider2D collider;

        private PlayerController playerController;

        private WeaponController weapon;



        private Vector3 startPosition;

        private GameObject explosionsParent;



        public int Lives
        {
            get { return lives; }
        }

        private void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            collider = GetComponent<PolygonCollider2D>();
            playerController = GetComponent<PlayerController>();
            weapon = GetComponent<WeaponController>();
            startPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            explosionsParent = GameObject.Find(ParentNames.EXPLOSIONS_PARENT_NAME);

            if (!explosionsParent)
            {
                explosionsParent = new GameObject(ParentNames.EXPLOSIONS_PARENT_NAME);
            }
        }

        public void Die()
        {
            StartCoroutine(DieCoroutine());
        }

        private IEnumerator DieCoroutine()
        {
            Debug.Log($"Die Coroutine");
            DisableComponents();
            GameObject explosion = Instantiate(explosionPrefab, explosionsParent.transform);
            explosion.transform.position = transform.position;

            lives--;
            yield return new WaitForSeconds(1.5f);

            if (lives > 0)
            {
                Respawn();
            }
        }

        private void Respawn()
        {
            transform.position = startPosition;
            EnableComponents();
        }


        private void EnableComponents()
        {
            SetComponentsEnabled(true);
        }

        private void DisableComponents()
        {
            SetComponentsEnabled(false);
        }


        private void SetComponentsEnabled(bool enabled)
        {
            spriteRenderer.enabled = enabled;
            collider.enabled = enabled;
            playerController.enabled = enabled;
            weapon.enabled = enabled;
            
        }




    }
}
