using UnityEngine;

public class SceneController : MonoBehaviour
{
    public GameObject pausePanel;

    private void Start()
    {
        Time.timeScale = 1f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausePanel.activeSelf)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        MusicController.Instance.ResumeMusic();
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }

    public void Pause()
    {
        MusicController.Instance.PauseMusic();
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
    }
}
