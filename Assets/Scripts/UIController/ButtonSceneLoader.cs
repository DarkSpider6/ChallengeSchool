using UnityEngine;
using UnityEngine.SceneManagement;

namespace UIController.Detail
{
    public class ButtonSceneLoader : MonoBehaviour
    {
        [SerializeField]
        private string gameSceneName = "Game Scene";
        [SerializeField]
        private string startSceneName = "Start Scene";

        public void LoadStartScene()
        {
            SceneManager.LoadScene(startSceneName);
        }
    
        public void LoadGameScene()
        {
            SceneManager.LoadScene(gameSceneName);
        }
    }
}
