using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionAnimation : MonoBehaviour
{
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    
    private bool _isFlipped = false;

    public float idleVelocityCutoff = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void UpdateAnimator(float direction, Vector2 velocity)
    {
        if (direction > 0)
        {
            _isFlipped = false;
        }
        if (direction < 0)
        {
            _isFlipped = true;
        }

        _spriteRenderer.flipX = _isFlipped;

        if (Mathf.Abs(velocity.x) > 0)
        {
            _animator.Play("Walk");
        }
        else
        {
            _animator.Play("Idle");
        }
    }

}
