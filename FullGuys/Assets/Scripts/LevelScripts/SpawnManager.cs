using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _characters;
    [SerializeField] private List<Transform> _spawnPoints;

    private void Awake()
    {
        _spawnPoints = new List<Transform>(_spawnPoints);
        SpawnCharacters();
    }

    private void SpawnCharacters()
    {
        for (int i = 0; i < _characters.Length; i++)
        {
            var RandomSpawn = Random.Range(0, _spawnPoints.Count);
            Instantiate(_characters[i], _spawnPoints[RandomSpawn].transform.position, _characters[i].transform.rotation);
            //_spawnPoints.RemoveAt(RandomSpawn);
        }
    }
}
