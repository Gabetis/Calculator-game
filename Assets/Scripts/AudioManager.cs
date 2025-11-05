using UnityEngine;
using System.Collections.Generic;
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private List<AudioClip> SFX;
    [SerializeField] private AudioClip BGM;

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
}
