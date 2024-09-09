using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Jumper : MonoBehaviour
{
    [SerializeField, Min(1)] private float _jumpForce = 10f;
    [SerializeField] private GroundChecker _groundChecker;

    private Rigidbody2D _rigidbody;
    private bool _isGround;
    private bool _isJumping;

    public event Action<bool> Jumped;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _groundChecker.GroundChanged += OnChengeGround;
    }

    private void OnDestroy()
    {
        _groundChecker.GroundChanged -= OnChengeGround;
    }

    private void FixedUpdate()
    {
        if (_isJumping && _isGround)
        {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
        }
    }

    private void Update()
    {
        TryJump();
    }

    private void OnChengeGround(bool isGround)
    {
        _isGround = isGround;
        
        if (_isGround)
        {
            _isJumping = false;
            Jumped?.Invoke(_isJumping);
        }
    }

    private void TryJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGround)
        {
            _isJumping = true;
            Jumped?.Invoke(_isJumping);
        }
    }
}
