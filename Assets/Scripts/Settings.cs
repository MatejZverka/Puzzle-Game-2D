using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Linq;

public class Settings : MonoBehaviour
{
    public AudioMixer audioMixer;
    public TMP_Dropdown resolutionDropdown;
    public Toggle fullscreenToggle;
    public Slider volumeSlider;
    public int fullscreen = 1;

    Resolution[] screenResolutions;

    public void Awake()
    {
        fullscreen = PlayerPrefs.GetInt("Fullscreen");
        if (fullscreen == 1)
            SetFullscreen(true);
        else
            SetFullscreen(false);

        resolutionDropdown.onValueChanged.AddListener(new UnityEngine.Events.UnityAction<int>(indexer =>
        {
            PlayerPrefs.SetInt("Resolution index", resolutionDropdown.value);
            PlayerPrefs.Save();
        }));
    }

    public void Start()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("Audio volume");
        audioMixer.SetFloat("MyExposedParam", volumeSlider.value * 10);

        screenResolutions = Screen.resolutions.Select(resolution => new Resolution { width = resolution.width, height = resolution.height }).Distinct().ToArray();

        resolutionDropdown.ClearOptions();

        List<string> resolutions = new List<string>();
        int currentResolution = 0;

        for (int i = 0; i < screenResolutions.Length; i++)
        {
            string resolution = screenResolutions[i].width + " x " + screenResolutions[i].height;
            resolutions.Add(resolution);

            if (screenResolutions[i].width == Screen.currentResolution.width &&
                screenResolutions[i].height == Screen.currentResolution.height)
            {
                currentResolution = i;
            }
        }

        resolutionDropdown.AddOptions(resolutions);
        resolutionDropdown.value = PlayerPrefs.GetInt("Resolution index", currentResolution);
        resolutionDropdown.RefreshShownValue();
    }

    public void SetVolume(float volume)
    {
        PlayerPrefs.SetFloat("Audio volume", volume);
        audioMixer.SetFloat("MyExposedParam", volume * 10);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        if (isFullscreen)
        {
            fullscreenToggle.isOn = true;
            Screen.fullScreen = true;
            fullscreen = 1;
        }
        else
        {
            fullscreenToggle.isOn = false;
            Screen.fullScreen = false;
            fullscreen = 0;
        }
        PlayerPrefs.SetInt("Fullscreen", fullscreen);
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = screenResolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

}
