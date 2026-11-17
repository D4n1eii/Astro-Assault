using UnityEngine;

namespace LearningProgrammingAcademy.AstroAssault
{

    [RequireComponent(typeof(AudioSource))]
    public class SoundController : MonoBehaviour
    {
        private AudioSource audioSource;
        private void Awake()
        {

            audioSource = GetComponent<AudioSource>();
        }

        public void PlayOneShot(AudioClip clip)
        {
            if (clip)
            {
                audioSource.PlayOneShot(clip);
            }
            
        }


        public void Play(AudioClip clip)
        {
            if (clip)
            {
                audioSource.clip = clip;
                audioSource.loop = true;
                audioSource.Play();
            }
        }


        public static SoundController FindSoundController()
        {
            var soundController = FindAnyObjectByType<SoundController>();
            if (!soundController)
            {
                Debug.Log("Couldn't find sound controller.");
            }

            return soundController;
        }
    }
}