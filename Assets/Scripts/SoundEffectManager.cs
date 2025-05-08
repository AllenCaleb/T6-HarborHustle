using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundEffectManager : MonoBehaviour
{
    private static SoundEffectManager Instance;

    [SerializeField] private Slider sfxSlider;
    [SerializeField] private AudioMixer audioMixer; // Drag your MainAudioMixer here
    private AudioSource audioSource;
    private SoundEffectLibrary soundEffectLibrary;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            audioSource = GetComponent<AudioSource>();
            soundEffectLibrary = GetComponent<SoundEffectLibrary>();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        float savedVolume = PlayerPrefs.GetFloat("SFXVolume", 1f);
        sfxSlider.value = savedVolume;
        SetVolume(savedVolume);
        sfxSlider.onValueChanged.AddListener(SetVolume);
    }

    public static void Play(string soundName)
    {
        if (Instance == null) return;

        AudioClip clip = Instance.soundEffectLibrary.GetRandomClip(soundName);
        if (clip != null && Instance.audioSource != null)
        {
            Instance.audioSource.PlayOneShot(clip);
        }
    }

    public void SetVolume(float volume)
    {
        if (audioMixer != null)
        {
            // Convert linear volume (0.0001 to 1.0) to decibels (-80 to 0)
            audioMixer.SetFloat("SFXVolume", Mathf.Log10(Mathf.Clamp(volume, 0.0001f, 1f)) * 20);
            PlayerPrefs.SetFloat("SFXVolume", volume);
        }
    }
}
