using UnityEngine;
using UnityEngine.UI;

namespace LearningProgrammingAcademy.AstroAssault.UI
{
    public class LifeIcon : MonoBehaviour
    {
        [SerializeField]
        private Image iconImage;

        private void Awake()
        {
            if (!iconImage)
            {
                iconImage = GetComponent<Image>();
            }
        }

        public void setImageColor(Color color)
        {
            if (iconImage)
            {
                iconImage.color = color;
            }
        }
    }
}