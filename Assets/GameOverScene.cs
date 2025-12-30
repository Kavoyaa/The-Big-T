using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScene : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 1f; // VERY IMPORTANT
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Retry()
    {
        SceneManager.LoadScene("Classroom"); // gameplay scene name
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
