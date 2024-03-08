using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{
    protected GameObject[] _characters;
    protected int _index;
    void Start()
    {
        _index = PlayerPrefs.GetInt("CharacterSelect");
        _characters = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            _characters[i] = transform.GetChild(i).gameObject;
        }
        foreach (var obj in _characters)
        {
            obj.SetActive(false);
        }
        if (_index >= 0 && _index < _characters.Length)
        {
            _characters[_index].SetActive(true);
        }
    }
    public void SelectLeft()
    {
        _characters[_index].SetActive(false);
        _index--;
        print(_index);
        if (_index < 0)
        {
            _index = _characters.Length - 1;
        }
        _characters[_index].SetActive(true);
    }
    public void SelectRight()
    {
        _characters[_index].SetActive(false);
        _index++;
        print(_index);
        if (_index == _characters.Length)
        {
            _index = 0;
        }
        _characters[_index].SetActive(true);
    }
    public void ActivateCharacter()
    {
        PlayerPrefs.SetInt("CharacterSelect", _index);
        SceneManager.LoadScene(1);
    }


}
