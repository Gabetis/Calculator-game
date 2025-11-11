using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private List<AudioClip> SFX;
    [SerializeField] private AudioClip BGM;
    [SerializeField] private Slider bgmSlider;

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
        LoadVolume();
        AudioListener.volume = bgmSlider.value;
        PlayBGM();
    }

    public void PlayCorrectSound()
    {
        audioSource.PlayOneShot(SFX[0]);
    }

    public void PlayWrongSound()
    {
        audioSource.PlayOneShot(SFX[1]);
    }

    public void TickTingSound()
    {
        audioSource.PlayOneShot(SFX[2]);
    }

    public void PlayButtonClickSound()
    {
        audioSource.PlayOneShot(SFX[3]);
    }

    public void SetVolume()
    {
        AudioListener.volume = bgmSlider.value;
        SaveVolume();
    }

    public void SaveVolume()
    {
        PlayerPrefs.SetFloat("bgmVolume", bgmSlider.value);
    }

    public void LoadVolume()
    {
        if (!PlayerPrefs.HasKey("bgmVolume"))
            PlayerPrefs.SetFloat("bgmVolume", 1f);
        else
        {
            bgmSlider.value = PlayerPrefs.GetFloat("bgmVolume", 0f);
        }
    }

    public void PlayBGM()
    {
        audioSource.clip = BGM;
        audioSource.loop = true;
        audioSource.Play();
    }
}
