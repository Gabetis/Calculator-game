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
    [SerializeField] private AudioSource clockSource;

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

        GameEvent.OnChangeScene += AddSlider;

        AddSlider();
    }

    private void Start()
    {
        //LoadVolume();

        //Initialize sliders and load saved volume settings
        //bgmSlider.onValueChanged.AddListener(SetBGMVolume);
        //sfxSlider.onValueChanged.AddListener(SetSFXVolume);

        //Apply loaded volume settings
        //SetBGMVolume(bgmSlider.value);
        //SetSFXVolume(sfxSlider.value);

        PlayBGM();
    }

    public void PlayCorrectSound() => sfxSource.PlayOneShot(SFX[0]);
    public void PlayWrongSound() => sfxSource.PlayOneShot(SFX[1]);
    public void PlayButtonClickSound() => sfxSource.PlayOneShot(SFX[2]);
    public void TickTingSound() => clockSource.PlayOneShot(SFX[3]);

    public void AddSlider()
    {
        if (bgmSlider == null)
        {
            var allSliders = FindObjectsByType<Slider>(FindObjectsInactive.Include, FindObjectsSortMode.None); //find all the slider in the scene including inactive objects
            bgmSlider = System.Array.Find(allSliders, s => s.name == "BGMSlider"); //find the slider with the name "BGMSlider" in the array
            if (bgmSlider != null)
            {
                if (!PlayerPrefs.HasKey("bgmVolume"))
                {
                    PlayerPrefs.SetFloat("bgmVolume", 1f);
                    bgmSlider.value = 1f;
                }
                else
                    bgmSlider.value = PlayerPrefs.GetFloat("bgmVolume", 0f);
                SetBGMVolume(bgmSlider.value); //set the bgmSource volume to the value of the slider
                bgmSlider.onValueChanged.AddListener(SetBGMVolume);
            }
        }

        if (sfxSlider == null)
        {
            var allSliders = FindObjectsByType<Slider>(FindObjectsInactive.Include, FindObjectsSortMode.None); //find all the slider in the scene including inactive objects
            sfxSlider = System.Array.Find(allSliders, s => s.name == "SFXSlider"); //find the slider with the name "SFXSlider" in the array
            if (sfxSlider != null)
            {
                if (!PlayerPrefs.HasKey("sfxVolume"))
                {
                    PlayerPrefs.SetFloat("sfxVolume", 1f);
                    sfxSlider.value = 1f;
                }
                else
                    sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume", 0f);
                SetSFXVolume(sfxSlider.value); //set the sfxSource volume to the value of the slider
                sfxSlider.onValueChanged.AddListener(SetSFXVolume);
            }
        }
    }

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
            bgmSlider.value = PlayerPrefs.GetFloat("bgmVolume", 0f);

        if (!PlayerPrefs.HasKey("sfxVolume"))
            PlayerPrefs.SetFloat("sfxVolume", 1f);
        else
            sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume", 0f);
    }

    public void PlayBGM()
    {
        bgmSource.clip = BGM;
        bgmSource.loop = true;
        bgmSource.Play();
    }

    private void OnDestroy()
    {
        GameEvent.OnChangeScene -= AddSlider;
    }
}
