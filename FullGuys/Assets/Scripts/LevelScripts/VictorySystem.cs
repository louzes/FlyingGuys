using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VictorySystem : MonoBehaviour
{
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private TMP_Text _text2;

    private List<GameObject> _finishOrder = new List<GameObject>();
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
                    if (_text != null && _text2 != null)
                    {
                        _text.text = "1 / 8";
                        _text2.text = "Perfect!";
                        _winPanel.SetActive(true);
                    }
                }
                else
                {
                    int place = _finishOrder.IndexOf(other.gameObject) + 1;
                    if (_text != null && _text2 != null)
                    {
                        _text.text = place + "/ 8";
                        _text2.text = "Good luck next time!";
                        _winPanel.SetActive(true);
                    }
                    Debug.Log("Player finished at place: " + place);
                }
            }
            if (other.CompareTag("AI"))
            {
                print("Bot detected");
                _finishOrder.Add(other.gameObject);
            }
        }
    }
}
