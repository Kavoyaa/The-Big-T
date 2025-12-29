using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;
    bool paused = false;

    void Start()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused) Resume();
            else Pause();
        }
    }

    void Pause()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
        paused = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Resume()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        paused = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
