using UnityEngine;
using LearningProgrammingAcademy.AstroAssault.Utils; 
namespace LearningProgrammingAcademy.AstroAssault
   
{
    public class WeaponController : MonoBehaviour
    {

        private const string SHOOT_METHOD_NAME = "Shoot";


        [SerializeField]
        private Bullet bulletPrefab;
        [SerializeField]
        private float bulletSpeed = 5f;

        [SerializeField]
        private float firingRate = 0.4f;


        private GameObject bulletsParent;


        private void Start() { 
            Debug.Log("Bullet spawned successfully on object: " + gameObject.name + " with position: " + transform.position);
            bulletsParent = GameObject.Find(ParentNames.BULLETS_PARENT_NAME);

            if (!bulletsParent)
            {
                bulletsParent = new GameObject(ParentNames.BULLETS_PARENT_NAME);
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                InvokeRepeating(SHOOT_METHOD_NAME, 0, firingRate);
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                CancelInvoke(SHOOT_METHOD_NAME);
            }
        }


        private void Shoot()
        {
            Vector3 spawnPos = transform.position + (Vector3)(Vector2.up * 0.5f);

            // Pass 'null' as the parent argument to spawn it standalone at the scene root
            Bullet bullet = Instantiate(bulletPrefab, spawnPos, Quaternion.identity, null);

            Rigidbody2D body = bullet.GetComponent<Rigidbody2D>();
            if (body != null)
            {
                body.linearVelocity = Vector2.up * bulletSpeed;
            }
        }
    }
}