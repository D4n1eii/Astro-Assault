using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LearningProgrammingAcademy.AstroAssault {

    public class PlayerController : MonoBehaviour {

        #region == constants ==
        private const string HORIZONTAL = "Horizontal";

        #endregion

        #region == fields ==
        [SerializeField]
        private float speed = 15f;

        [SerializeField]
        private float xmin = -7.2f;

        [SerializeField]
        private float xmax = 7.2f;

        [SerializeField]
        private float padding = 0.8f;

        private Rigidbody2D body;

        #endregion

        #region == messages ==
        private void Start() {
            body = GetComponent<Rigidbody2D>();
        }

        // This function is called every fixed framerate frame, if the MonoBehaviour is enabled
        private void FixedUpdate() {
            float horizontalMovement = Input.GetAxis(HORIZONTAL);

            body.linearVelocity = new Vector2(horizontalMovement * speed, 0f);

            // restrict player movement between xmin and xmax
            float newX = Mathf.Clamp(body.position.x, xmin + padding, xmax - padding);
            body.position = new Vector2(newX, body.position.y);
        }

        #endregion
    }
}
