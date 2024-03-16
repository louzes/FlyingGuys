using UnityEngine;

public class BotAnimationController : MonoBehaviour
{
    private Animator _animator;
    private AIMovement _aIMovement;
    void Start()
    {
        _animator = GetComponent<Animator>();
        _aIMovement = GetComponentInParent<AIMovement>();
    }

    void Update()
    {
        _animator.SetBool("Running", _aIMovement._speed >= 0);
    }
}
