using UnityEngine;
using UnityEngine.SceneManagement;
using LearningProgrammingAcademy.AstroAssault.Utils;
namespace LearningProgrammingAcademy.AstroAssault.Scene
{
    public class MainMenuSceneController : MonoBehaviour
    {

        public void PlayOnClick()
        {
            SceneManager.LoadSceneAsync(SceneNames.LEVEL);
        }


        public void OptionsOnClick()
        {
            SceneManager.LoadSceneAsync(SceneNames.OPTIONS,LoadSceneMode.Additive);
        }
    }
} 