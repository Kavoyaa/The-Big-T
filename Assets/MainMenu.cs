using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("MainScene"); // replace with your actual scene name
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
