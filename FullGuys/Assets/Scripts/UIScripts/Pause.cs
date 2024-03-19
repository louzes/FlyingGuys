using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject PanelPaused;
    public bool IsPaused;
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
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
