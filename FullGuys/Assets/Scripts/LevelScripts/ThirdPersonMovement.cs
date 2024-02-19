using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    [Header("Basics")]
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private Transform _cam;

    [Header("Camera Settings")]
    [SerializeField] private float _speed = 6f;
    [SerializeField] private float _turnSmoothTime = .1f;
    [HideInInspector] private float _turnSmoothSpeed;

    [Header("Jumping Settings")]
    [SerializeField] private float _jumpSpeed = 8.0f;
    [SerializeField] private float _gravity = 20.0f;
    private float _verticalVelocity;

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + _cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothSpeed, _turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            _characterController.Move(moveDirection.normalized * _speed * Time.deltaTime);
        }
        Jump();
    }
    void Jump()
    {
        if (_characterController.isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            _verticalVelocity = _jumpSpeed;
        }
        else
        {
            _verticalVelocity -= _gravity * Time.deltaTime;
        }

        Vector3 moveDirection = new Vector3(0, _verticalVelocity, 0);
        _characterController.Move(moveDirection * Time.deltaTime);
    }

}
