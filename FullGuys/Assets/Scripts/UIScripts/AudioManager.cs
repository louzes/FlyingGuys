using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioSource _sfxSource;
    [Header("Audio Clip")]
    [SerializeField] private AudioClip _roar;
    [SerializeField] private AudioClip _background;
    [Space]
    [SerializeField] private AudioClip _clickButton;
    void Start()
    {
        _musicSource.clip = _background;
        _musicSource.Play();
    }
    public void PlaySFX(AudioClip clip)
    {
        _sfxSource.PlayOneShot(clip);
    }
}
