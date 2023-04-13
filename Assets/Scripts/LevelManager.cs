using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private float buttonLoadDelay = 0.5f;
    public static bool isPaused = false;
    public GameObject pauseMenuPanel;

    // Keyboard navigation
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PlayButtonPress();

            if (SceneManager.GetActiveScene().buildIndex <= 2)
            {
                GoToMainMenu();
            }

            if (SceneManager.GetActiveScene().buildIndex >= 3)
            {
                if (isPaused)
                {
                    pauseMenuPanel.SetActive(false);
                    Time.timeScale = 1f;
                    isPaused = false;
                }
                else
                {
                    pauseMenuPanel.SetActive(true);
                    Time.timeScale = 0f;
                    isPaused = true;
                }
            }
        }

        if ((Input.GetKeyDown(KeyCode.R)) && (SceneManager.GetActiveScene().buildIndex >= 3))
        {
            ReloadLevel();
        }
    }

    // Button audio
    public void PlayButtonHover() { AudioPlayer.instance.PlayButtonHoverClip(); }
    public void PlayButtonPress() { AudioPlayer.instance.PlayButtonPressClip(); }

    // Menu buttons
    public void GoToLevelSelect() { StartCoroutine(WaitAndLoad("Level Select", buttonLoadDelay)); }
    public void GoToSettings() { StartCoroutine(WaitAndLoad("Settings", buttonLoadDelay)); }
    public void GoToMainMenu() { StartCoroutine(WaitAndLoad("Main Menu", buttonLoadDelay)); }
    public void QuitGame() { Application.Quit(); }
    public void ReloadLevel()
    {
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }

    public void ResumeLevelFromPauseMenu()
    {
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    // Level Select buttons
    public void LoadLevel01() { StartCoroutine(WaitAndLoad("Level 01", buttonLoadDelay)); }
    public void LoadLevel02() { StartCoroutine(WaitAndLoad("Level 02", buttonLoadDelay)); }
    public void LoadLevel03() { StartCoroutine(WaitAndLoad("Level 03", buttonLoadDelay)); }
    public void LoadLevel04() { StartCoroutine(WaitAndLoad("Level 04", buttonLoadDelay)); }
    public void LoadLevel05() { StartCoroutine(WaitAndLoad("Level 05", buttonLoadDelay)); }
    public void LoadLevel06() { StartCoroutine(WaitAndLoad("Level 06", buttonLoadDelay)); }
    public void LoadLevel07() { StartCoroutine(WaitAndLoad("Level 07", buttonLoadDelay)); }
    public void LoadLevel08() { StartCoroutine(WaitAndLoad("Level 08", buttonLoadDelay)); }
    public void LoadLevel09() { StartCoroutine(WaitAndLoad("Level 09", buttonLoadDelay)); }
    public void LoadLevel10() { StartCoroutine(WaitAndLoad("Level 10", buttonLoadDelay)); }
    public void LoadLevel11() { StartCoroutine(WaitAndLoad("Level 11", buttonLoadDelay)); }
    public void LoadLevel12() { StartCoroutine(WaitAndLoad("Level 12", buttonLoadDelay)); }
    public void LoadLevel13() { StartCoroutine(WaitAndLoad("Level 13", buttonLoadDelay)); }
    public void LoadLevel14() { StartCoroutine(WaitAndLoad("Level 14", buttonLoadDelay)); }
    public void LoadLevel15() { StartCoroutine(WaitAndLoad("Level 15", buttonLoadDelay)); }

    IEnumerator WaitAndLoad(string sceneName, float delay)
    {
        Time.timeScale = 1f;
        isPaused = false;
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
