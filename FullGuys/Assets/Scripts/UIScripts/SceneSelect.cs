using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelect : MonoBehaviour
{
    public static SceneSelect Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        //else
        //{
        //    Destroy(gameObject);
        //}
    }
    public void Menu() => SceneManager.LoadScene(0);

    public void LevelOne() => SceneManager.LoadScene(1);

}
