using UnityEngine;


namespace LearningProgramAcademy.AstroAssault
{

    [RequireComponent(typeof(Rigidbody2D))]
    public class FallingBehaviour : MonoBehaviour
    {
        // == fields == 
        [SerializeField]
        private float speed = 2f;

        private Rigidbody2D body;

        private void Start()
        {
            body = GetComponent<Rigidbody2D>();

        }

        private void FixedUpdate()
        {
            body.linearVelocity = Vector2.down * speed;
        }
    }

}