using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    public AudioSource MusicSource;
    public AudioSource SfxSource;
    [Header("Audio Clip")]
    public AudioClip PlayerDeath;
    public AudioClip Background;
    public AudioClip FootSteps;
    public AudioClip Teleport;
    public AudioClip Victory;
    public AudioClip Bloop;
    [Space(20f)]
    public AudioClip ClickButton;
    void Start()
    {
        MusicSource.clip = Background;
        MusicSource.Play();
    }
    public void PlaySFX(AudioClip clip)
    {
        SfxSource.PlayOneShot(clip);
    }
    public void StopMusic(bool state)
    {
        if (state)
        {
            MusicSource.Pause();
        }
        else
        {
            MusicSource.UnPause();
        }
    }
}
