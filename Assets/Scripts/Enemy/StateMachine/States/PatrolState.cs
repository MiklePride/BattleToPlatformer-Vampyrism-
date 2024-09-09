using System;
using UnityEngine;

[RequireComponent(typeof(EnemyMover))]
public class PatrolState : State
{
    [SerializeField, Min(1)] private float _speed = 4f;
    [SerializeField] private Transform _patrolPath;

    private EnemyMover _mover;
    private Transform[] _patrolPoints;
    private int _pointIndex = 0;

    public event Action Patrolled;

    private void Awake()
    {
        _mover = GetComponent<EnemyMover>();

        _patrolPoints = new Transform[_patrolPath.childCount];

        for (int i = 0; i < _patrolPoints.Length; i++)
        {
            _patrolPoints[i] = _patrolPath.GetChild(i);
        }
    }

    private void OnEnable()
    {
        NextPoint();
        Patrolled?.Invoke();
    }

    private void Update()
    {
        if (_patrolPath != null)
        {
            if (transform.position.x == _patrolPoints[_pointIndex].position.x)
                NextPoint();
        }
    }

    private void NextPoint()
    {
        _pointIndex++;

        if (_pointIndex == _patrolPoints.Length)
            _pointIndex = 0;

        _mover.SetTargetPoint(_patrolPoints[_pointIndex], _speed);
    }
}
