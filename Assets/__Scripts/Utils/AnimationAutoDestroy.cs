using UnityEngine;

namespace LearningProgrammingAcademy.Utils
{
    [RequireComponent(typeof(Animator))]
    public class AnimationAutoDestroy : MonoBehaviour
    {

        [SerializeField]
        private float destroyDelay = 0.1f;



        private Animator animator;


        private void Start()
        {
            animator = GetComponent<Animator>();
            float animationLength = animator.GetCurrentAnimatorStateInfo(0).length;
            float totalTime = animationLength + destroyDelay;
            Destroy(gameObject, totalTime);
        }

    }
}