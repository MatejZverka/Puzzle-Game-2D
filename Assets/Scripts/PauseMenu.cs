using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseMenuPanel;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
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

}
