using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    [Header("Audio Clips")]
    [SerializeField] private AudioClip BGM;
    [SerializeField] private List<AudioClip> SFX;

    [Header("Audio Source")]
    [SerializeField] private AudioSource bgmSource;
    [SerializeField] private AudioSource sfxSource;

    [Header("Slider")]
    [SerializeField] private Slider bgmSlider;
    [SerializeField] private Slider sfxSlider;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Initialize sliders and load saved volume settings
        bgmSlider.onValueChanged.AddListener(SetBGMVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);

        LoadVolume();

        // Apply loaded volume settings
        SetBGMVolume(bgmSlider.value);
        SetSFXVolume(sfxSlider.value);

        PlayBGM();
    }

    public void PlayCorrectSound() => sfxSource.PlayOneShot(SFX[0]);
    public void PlayWrongSound() => sfxSource.PlayOneShot(SFX[1]);
    public void TickTingSound() => sfxSource.PlayOneShot(SFX[2]);
    public void PlayButtonClickSound() => sfxSource.PlayOneShot(SFX[3]);

    public void SetBGMVolume(float value)
    {
        bgmSource.volume = value;
        PlayerPrefs.SetFloat("bgmVolume", value);
    }

    public void SetSFXVolume(float value)
    {
        sfxSource.volume = value;
        PlayerPrefs.SetFloat("sfxVolume", value);
    }

    public void LoadVolume()
    {
        if (!PlayerPrefs.HasKey("bgmVolume"))
            PlayerPrefs.SetFloat("bgmVolume", 1f);
        else
        {
            bgmSlider.value = PlayerPrefs.GetFloat("bgmVolume", 0f);
        }

        if(!PlayerPrefs.HasKey("sfxVolume"))
            PlayerPrefs.SetFloat("sfxVolume", 1f);
        else
        {
            sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume", 0f);
        }
    }

    public void PlayBGM()
    {
        bgmSource.clip = BGM;
        bgmSource.loop = true;
        bgmSource.Play();
    }
}
