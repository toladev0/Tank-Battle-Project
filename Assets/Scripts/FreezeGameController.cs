using UnityEngine;

public class FreezeGameController : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject pausePanel;
    public GameObject winPanel;

    [Header("Audio")]
    public GameObject Theme;

    private AudioSource ThemeAs;

    private void Start()
    {
        // Safely get the AudioSource component if battleAudioObject is assigned
        if (Theme != null)
        {
            ThemeAs = Theme.GetComponent<AudioSource>();
        }
    }

    private void Update()
    {
        HandleGameState();
    }

    private void HandleGameState()
    {
        // Check if either the pause or win panel is active
        if (pausePanel != null && winPanel != null)
        {
            bool isGamePaused = pausePanel.activeSelf; // || winPanel.activeSelf

            // Update time scale and audio playback based on game state
            Time.timeScale = isGamePaused ? 0f : 1f;

            if (ThemeAs != null)
            {
                if (isGamePaused)
                {
                    ThemeAs.Pause();
                }
                else
                {
                    ThemeAs.UnPause();
                }
            }
        }
    }
}
