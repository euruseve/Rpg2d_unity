using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10;
    private Rigidbody2D _rb;
    private Animator _animator;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        _rb.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * moveSpeed;

        Animate();
    }

    private void Animate()
    {
        _animator.SetFloat("moveX", _rb.velocity.x);
        _animator.SetFloat("moveY", _rb.velocity.y);

        if(Input.GetAxisRaw("Horizontal") == 1 || 
        Input.GetAxisRaw("Horizontal") == -1 || 
        Input.GetAxisRaw("Vertical") == 1 || 
        Input.GetAxisRaw("Vertical") == -1)
        {
            _animator.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
            _animator.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
        }
    }
}
