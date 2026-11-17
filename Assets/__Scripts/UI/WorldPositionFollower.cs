using UnityEngine;
namespace LearningProgrammingAcademy.AstroAssault.UI
{
    public class WorldPositionFollower : MonoBehaviour
    {
        [SerializeField]
        private Transform positionToFollow;


        private void LateUpdate()
        {
            if (positionToFollow)
            {
                Vector3 screenPosition = Camera.main.WorldToScreenPoint(positionToFollow.position);
                transform.position = screenPosition;
            }
        }


    }
}