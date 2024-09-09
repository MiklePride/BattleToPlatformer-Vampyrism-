using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(EnemyMover))]
public class AttackState : State
{
    [SerializeField] private PlayerTrigger _attackTrigger;
    [SerializeField, Min(1)] private float _damage = 4;
    [SerializeField] private float _durationPauseBetweenAttack = 3f;

    private Player _target;
    private float _timeSinceLastAttack;
    private EnemyMover _mover;
    private Coroutine _attack;

    public Func<float> Attacked;
    public event Action Stoped;

    private void Awake()
    {
        _mover = GetComponent<EnemyMover>();
    }

    private void OnEnable()
    {
        _mover.Stop();
        Stoped?.Invoke();

        _target = _attackTrigger.Target;
    }

    private void Update()
    {
        _timeSinceLastAttack += Time.deltaTime;

        Attack();
    }

    private IEnumerator DoDamage(float delayBeforeDealingDamage)
    {
        yield return new WaitForSeconds(delayBeforeDealingDamage);

        _target.TakeDamage(_damage);
    }

    private void Attack()
    {
        if (_target != null && _timeSinceLastAttack >= _durationPauseBetweenAttack)
        {
            if (_attack != null)
                StopCoroutine(_attack);

            StartCoroutine(DoDamage(Attacked.Invoke()));
            
            _timeSinceLastAttack = 0;
        }
    }
}
