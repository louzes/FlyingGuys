using UnityEngine;

public class MovingWallAnimation : MonoBehaviour
{
    [SerializeField] private float _moveDistance = 3f;
    [SerializeField] private float _moveSpeed = 4f;

    private Vector3 _initialPosition;
    private Vector3 _targetPosition;
    private bool _movingRight = true;

    private void Start()
    {
        _initialPosition = transform.localPosition;
        _targetPosition = _initialPosition + Vector3.right * _moveDistance;
    }
    private void Update()
    {
        if (_movingRight)
        {
            MovePlatform(_targetPosition);
            if (transform.localPosition.x >= _targetPosition.x)
            {
                _movingRight = false;
            }
        }
        else
        {
            MovePlatform(_initialPosition);
            if (transform.localPosition.x <= _initialPosition.x)
            {
                _movingRight = true;
            }
        }
    }


    private void MovePlatform(Vector3 target)
    {
        float step = _moveSpeed * Time.deltaTime;
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, target, step);
    }
}
