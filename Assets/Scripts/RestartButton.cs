using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    public void LoadScene(int number)
    {
        SceneManager.LoadScene(0);
        SceneManager.LoadScene(number);
    }
}
