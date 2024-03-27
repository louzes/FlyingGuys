using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator _animator;
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    private void Update()
    {
        _animator.SetBool("Running", Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S));
        _animator.SetBool("Jumping", Input.GetKeyDown(KeyCode.Space));       
    }
}
