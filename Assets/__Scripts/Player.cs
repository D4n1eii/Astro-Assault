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

        [SerializeField]
        private AudioClip playerDieClip;

        [SerializeField]
        private AudioClip respawnClip;

        private Vector3 startPosition;

        private GameObject explosionsParent;

        [SerializeField] private SoundController soundController;
        public delegate void LostLifeDelegate(int livesLeft);

        public static event LostLifeDelegate LostLifeEvent;

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
            explosionsParent = GameObject.Find(ParentUtils.EXPLOSIONS_PARENT_NAME);

            if (!explosionsParent)
            {
                explosionsParent = new GameObject(ParentUtils.EXPLOSIONS_PARENT_NAME);
            }
        }

        public void Die()
        {
            StartCoroutine(DieCoroutine());
        }

        private IEnumerator DieCoroutine()
        {
            DisableComponents();
            GameObject explosion = Instantiate(explosionPrefab, explosionsParent.transform);
            explosion.transform.position = transform.position;

            lives--;
            PublishLostLifeEvent();
            soundController.PlayOneShot(playerDieClip);
            yield return new WaitForSeconds(1.5f);

            if (lives > 0)
            {
                Respawn();
                soundController.PlayOneShot(respawnClip);
            }
        }


        private IEnumerator RespawnAnimCoroutine()
        {
            for (int i = 0; i <6; i++)
            {
                spriteRenderer.color = new Color(255f, 255f, 255f, .5f);
                yield return new WaitForSeconds(0.2f);
                spriteRenderer.color = new Color(255f, 255f, 255f, 255f);
            }
        }


        private void Respawn()
        {
            StartCoroutine(RespawnAnimCoroutine());
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



        private void PublishLostLifeEvent()
        {
            LostLifeEvent?.Invoke(lives);
        }

       
    }
}
