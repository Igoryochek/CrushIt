using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class RestartButton : MonoBehaviour
    {
        private const int StartScene = 0;

        public void LoadScene(int number)
        {
            SceneManager.LoadScene(StartScene);
            SceneManager.LoadScene(number);
        }
    }
}


