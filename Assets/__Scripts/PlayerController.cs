using UnityEngine;
using UnityEngine.InputSystem;


namespace LearningProgramAcademy.AstroAssault
{

    public class PlayerController : MonoBehaviour
    {


        #region == constants ==
        private const string HORIZONTAL = "Horizontal";
        #endregion
        #region == fields == 
        private Rigidbody2D body;
        [SerializeField]
        private float speed = 15f;

            [SerializeField]
            private float padding = 0.8f;


        [SerializeField]
        private float xmin = -7.2f;
        [SerializeField]

        private float xmax = 7.2f;
        #endregion  

        #region == messages == 

        private void Start()
        {
            body = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            float horizontalMovement = 0f;

            if (Keyboard.current.leftArrowKey.isPressed)
                horizontalMovement = -1f;

            if (Keyboard.current.rightArrowKey.isPressed)
                horizontalMovement = 1f;

            body.linearVelocity = new Vector2(
                horizontalMovement * speed,
                body.linearVelocity.y
            );

            float newX = Mathf.Clamp(body.position.x, xmin+padding, xmax-padding);
            body.position = new Vector2(newX, body.position.y);
        }

    }



        #endregion
    }
