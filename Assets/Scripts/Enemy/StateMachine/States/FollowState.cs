using System;
using UnityEngine;

[RequireComponent(typeof(EnemyMover))]
public class FollowState : State
{
    [SerializeField, Min(1)] private float _speed = 7f;
    [SerializeField] private PlayerTrigger _followTrigger;

    private EnemyMover _mover;
    private Player _target;

    public event Action Followed;

    private void Awake()
    {
        _mover = GetComponent<EnemyMover>();
    }

    private void OnEnable()
    {
        FollowTarget(_followTrigger.Target);
        Followed?.Invoke();
    }

    private void FollowTarget(Player target)
    {
        _target = target;
        
        if (_target != null)
            _mover.SetTargetPoint(_target.transform, _speed);
    }
}
