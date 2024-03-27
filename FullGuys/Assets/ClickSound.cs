using UnityEngine;

public class ClickSound : MonoBehaviour
{
    private AudioManager _audioManager;

    private void Awake()
    {
        _audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }

    public void ClickAction()
    {
        _audioManager.PlaySFX(_audioManager.ClickButton);
    }
}
