using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class VictorySystem : MonoBehaviour
{
    [SerializeField] private GameObject _winPanel;
    [Space]
    [SerializeField] private Text _text01;
    [SerializeField] private Text _text02;

    private List<GameObject> _finishOrder = new List<GameObject>();

    private void Start() => _winPanel.SetActive(false);

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.layer == 12)
        {
            if (other.CompareTag("Player"))
            {
                print("Player detected");
                _finishOrder.Add(other.gameObject);
                if (_finishOrder[0] == other.gameObject && _winPanel != null)
                {
                    if (_text01 != null && _text02 != null)
                    {
                        _text01.text = "1 / 8";
                        _text02.text = "Perfect!";
                        _winPanel.SetActive(true);
                        CoroutineStarter();
                    }
                }
                else
                {
                    int place = _finishOrder.IndexOf(other.gameObject) + 1;
                    if (_text01 != null && _text02 != null)
                    {
                        _text01.text = place + " / 8";
                        _text02.text = "Good luck next time!";
                        _winPanel.SetActive(true);
                        CoroutineStarter();
                    }
                    print("Player finished at place: " + place);
                }
            }
            if (other.CompareTag("AI"))
            {               
                print("Bot detected");
                _finishOrder.Add(other.gameObject);
                other.gameObject.SetActive(false);
            }
        }
    }
    IEnumerator BackToMenu()
    {
        yield return new WaitForSeconds(4f);
        Time.timeScale = 0f;
        SceneSelect.Instance.Menu();
    }
    private void CoroutineStarter()
    {
        StartCoroutine(BackToMenu());       
    }
}
