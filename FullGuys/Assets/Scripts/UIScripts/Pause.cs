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
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
}
