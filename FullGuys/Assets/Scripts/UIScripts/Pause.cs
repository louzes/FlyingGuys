using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject PanelPaused;
    public bool IsPaused;

    private AudioManager _audioManager;

    private void Awake()
    {
        _audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            IsPaused = !IsPaused;
            PanelPaused.SetActive(IsPaused);
        }
        if (IsPaused == true)
        {
            Time.timeScale = 0f;
            _audioManager.StopMusic(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Time.timeScale = 1f;
            _audioManager.StopMusic(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
