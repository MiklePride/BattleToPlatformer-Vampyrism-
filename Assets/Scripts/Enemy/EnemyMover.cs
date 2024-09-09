using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    private float _currentSpeed;
    private Transform _target;

    private void Update()
    {
        if (_target != null)
        {
            Move();
            FlipFace();
        }
    }

    private void Move()
    {
        var targetPosition = new Vector2(_target.position.x, transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, _currentSpeed * Time.deltaTime);
    }

    private void FlipFace()
    {
        float angleTurningToRight = 180;
        float angleTurningToLeft = 0;
        Quaternion rotation = Quaternion.identity;

        if (_target.position.x < transform.position.x)
            rotation = Quaternion.Euler(0, angleTurningToLeft, 0);

        if (_target.position.x > transform.position.x)
            rotation = Quaternion.Euler(0, angleTurningToRight, 0);

        transform.rotation = rotation;
    }

    public void SetTargetPoint(Transform target, float speed)
    {
        _target = target;
        _currentSpeed = speed;
    }

    public void Stop()
    {
        _target = null;
    }
}