using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [Header("Map Selection")]
    public int selectedMap;

    [Header("Sound Controls")]
    public GameObject soundOnIcon;
    public GameObject soundOffIcon;

    [Header("Screen Controls")]
    public GameObject FullScreenIcon;
    public GameObject WindowedIcon;

    private void Start()
    {
        UpdateSoundIcons();
        UpdateScreenIcons();
    }

    // Loads the selected map
    public void PlayGame()
    {
        if (selectedMap <= 0)
        {
            Debug.LogError("Selected map must be greater than 0.");
            return;
        }

        SceneManager.LoadScene("Map " + selectedMap);
    }

    // Restarts the current game scene
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Quits the application
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game exited."); // Optional for debugging purposes.
    }

    // Navigates to the Start Menu
    public void GoToStartMenu()
    {
        SceneManager.LoadScene("Start Menu");
    }

    // Mutes the game audio
    public void Mute()
    {
        AudioListener.volume = 0;
        UpdateSoundIcons();
    }

    // Unmutes the game audio
    public void Unmute()
    {
        AudioListener.volume = 1;
        UpdateSoundIcons();
    }

    // Updates the sound icons based on the current volume state
    private void UpdateSoundIcons()
    {
        if (soundOnIcon != null && soundOffIcon != null)
        {
            if (AudioListener.volume == 1)
            {
                soundOnIcon.SetActive(true);
                soundOffIcon.SetActive(false);
            }
            else
            {
                soundOnIcon.SetActive(false);
                soundOffIcon.SetActive(true);
            }
        }
    }

    // FullScreen
    public void Fullscreen()
    {
        // Set to fullscreen and update resolution if needed
        Screen.SetResolution(1920, 1080, true);
    }

    // Windowed
    public void Windowed()
    {
        // Set to windowed and choose a specific resolution
        Screen.SetResolution(1920, 1080, false);  // Example resolution for windowed mode
    }

    private void UpdateScreenIcons()
    {
        if (Screen.fullScreen)
        {
            FullScreenIcon.SetActive(true);
            WindowedIcon.SetActive(false);
        }
        else
        {
            FullScreenIcon.SetActive(false);
            WindowedIcon.SetActive(true);
        }
    }
}
