using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioPlayer : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] AudioClip buttonHover;
    [SerializeField] AudioClip buttonPress;
    [SerializeField][Range(0f, 1f)] float buttonVolume = 0.5f;

    [Header("Gameplay")]
    [SerializeField] AudioClip dash;
    [SerializeField][Range(0f, 1f)] float dashVolume = 0.5f;
    [SerializeField] AudioClip finish;
    [SerializeField][Range(0f, 1f)] float finishVolume = 0.9f;


    public static AudioPlayer instance;
    public AudioMixer audioMixer;

    public AudioPlayer GetInstance()
    {
        return instance;
    }

    void Awake()
    {
        ManageSingleton();
    }

    public void Start()
    {
        audioMixer.SetFloat("MyExposedParam", PlayerPrefs.GetFloat("Audio volume") * 10);
    }

    void ManageSingleton()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayButtonHoverClip()
    {
        PlayClip(buttonHover, buttonVolume);
    }

    public void PlayButtonPressClip()
    {
        PlayClip(buttonPress, buttonVolume);
    }

    public void PlayDashClip()
    {
        PlayClip(dash, dashVolume);
    }

    public void PlayFinishClip()
    {
        PlayClip(finish, finishVolume);
    }

    public void PlayClip(AudioClip clip, float volume)
    {
        if (clip != null)
        {
            Vector3 cameraPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip, cameraPos, ((PlayerPrefs.GetFloat("Audio volume") + 8) / 8) * volume);
        }
    }

    public void DeleteSaveData()
    {
        PlayerPrefs.DeleteKey("Level 01");
        PlayerPrefs.DeleteKey("Level 02");
        PlayerPrefs.DeleteKey("Level 03");
        PlayerPrefs.DeleteKey("Level 04");
        PlayerPrefs.DeleteKey("Level 05");
        PlayerPrefs.DeleteKey("Level 06");
        PlayerPrefs.DeleteKey("Level 07");
        PlayerPrefs.DeleteKey("Level 08");
        PlayerPrefs.DeleteKey("Level 09");
        PlayerPrefs.DeleteKey("Level 10");
        PlayerPrefs.DeleteKey("Level 11");
        PlayerPrefs.DeleteKey("Level 12");
        PlayerPrefs.DeleteKey("Level 13");
        PlayerPrefs.DeleteKey("Level 14");
        PlayerPrefs.DeleteKey("Level 15");
    }
}
