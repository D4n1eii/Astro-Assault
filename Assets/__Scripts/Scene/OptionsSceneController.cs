using UnityEngine;
using UnityEngine.SceneManagement;
using LearningProgrammingAcademy.AstroAssault.Utils;
namespace LearningProgrammingAcademy.AstroAssault.Scene
{
    public class OptionsSceneController : MonoBehaviour
    {
        public void BackOnClick()
        {
            SceneManager.UnloadSceneAsync(SceneNames.OPTIONS);
        } 




    }
}