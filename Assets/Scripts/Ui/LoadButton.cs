using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class LoadButton : MonoBehaviour
    {
        public void LoadScene(int number)
        {
            SceneManager.LoadScene(number);
        }
    }
}