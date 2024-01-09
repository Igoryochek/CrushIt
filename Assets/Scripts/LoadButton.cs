using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadButton : MonoBehaviour
{
    public void LoadScene(int number)
    {
        SceneManager.LoadScene(number);
    }
}
