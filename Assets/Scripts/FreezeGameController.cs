using UnityEngine;

public class FreezeGameController : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject pausePanel;
    public GameObject winPanel;

    [Header("Audio")]
    public GameObject battleAudioObject;

    private AudioSource battleAudioSource;

    private void Start()
    {
        // Safely get the AudioSource component if battleAudioObject is assigned
        if (battleAudioObject != null)
        {
            battleAudioSource = battleAudioObject.GetComponent<AudioSource>();
        }
        else
        {
            Debug.LogWarning("BattleAudioObject is not assigned in the Inspector.");
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

            if (battleAudioSource != null)
            {
                if (isGamePaused)
                {
                    battleAudioSource.Pause();
                }
                else
                {
                    battleAudioSource.UnPause();
                }
            }
        }
        else
        {
            Debug.LogError("PausePanel or WinPanel is not assigned in the Inspector.");
        }
    }
}
