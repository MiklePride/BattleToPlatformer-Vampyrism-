using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);

    [SerializeField, Min(0)] private float _speed = 8f;

    private Rigidbody2D _rigidbody;
    private bool _isFacingRight = true;
    private float _horizontalMove;

    public bool IsMove => _horizontalMove != 0;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 targetVelocity = new Vector2(_horizontalMove, _rigidbody.velocity.y);
        _rigidbody.velocity = targetVelocity;
    }

    private void Update()
    {
        _horizontalMove = Input.GetAxis(Horizontal) * _speed;
        _isFacingRight = _horizontalMove == 0 ? _isFacingRight : _horizontalMove > 0;

        FlipFace();
    }

    private void FlipFace()
    {
        float angleTurningToRight = 0;
        float angleTurningToLeft = 180;
        Quaternion rotation = Quaternion.identity;

        if (_isFacingRight)
            rotation = Quaternion.Euler(0, angleTurningToRight, 0);

        if (!_isFacingRight)
            rotation = Quaternion.Euler(0, -angleTurningToLeft, 0);

        transform.rotation = rotation;
    }
}