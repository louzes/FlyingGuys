using System.Collections.Generic;
using UnityEngine;

public class DronsAnimation : MonoBehaviour
{
    [Header("Dron Settings")]
    [SerializeField] private float _moveDistance = 3f;
    [SerializeField] private float _moveSpeed = 4f;
    [SerializeField] private bool _activate = true;

    private Vector3 _initialPosition;
    private Vector3 _targetPosition;
    private bool _movingUp = true;

    [Header("Propeller Settings")]
    [SerializeField] private List<GameObject> _propellers;
    [SerializeField] private float _propSpeed;

    private void Start()
    {
        if (_activate == true)
        {
            _initialPosition = transform.position;
            _targetPosition = _initialPosition + Vector3.up * _moveDistance;
        }
    }

    private void FixedUpdate()
    {
        if (_activate == true)
        {
            if (_movingUp)
            {
                MovePlatform(_targetPosition);
                if (transform.position.y >= _targetPosition.y)
                {
                    _movingUp = false;
                }
            }
            else
            {
                MovePlatform(_initialPosition);
                if (transform.position.y <= _initialPosition.y)
                {
                    _movingUp = true;
                }
            }
        }
        foreach (GameObject obj in _propellers)
        {
            Transform objTransform = obj.transform;
            objTransform.localRotation *= Quaternion.Euler(0f, _propSpeed, 0f);
        }
    }

    private void MovePlatform(Vector3 target)
    {
        float step = _moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, step);
    }
}
