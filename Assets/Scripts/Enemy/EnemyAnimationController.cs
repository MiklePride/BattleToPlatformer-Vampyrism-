using UnityEngine;

[RequireComponent(typeof(Enemy), typeof(DeathState), typeof(Animator))]
[RequireComponent(typeof(PatrolState), typeof(FollowState), typeof(AttackState))]
public class EnemyAnimationController : MonoBehaviour
{
    [SerializeField] private AnimationClip _attackAnimation;

    private int _animStateID = Animator.StringToHash("AnimState");
    private int _attackID = Animator.StringToHash("Attack");
    private int _hurtID = Animator.StringToHash("Hurt");
    private int _deathID = Animator.StringToHash("Death");
    private int _animationSpeedID = Animator.StringToHash("AnimationSpeed");

    private Animator _animator;
    private Enemy _enemy;
    private DeathState _deathState;
    private PatrolState _patrolState;
    private FollowState _followState;
    private AttackState _attackState;

    private void Awake()
    {
        _deathState = GetComponent<DeathState>();
        _enemy = GetComponent<Enemy>();
        _animator = GetComponent<Animator>();
        _patrolState = GetComponent<PatrolState>();
        _followState = GetComponent<FollowState>();
        _attackState = GetComponent<AttackState>();
    }

    private void OnEnable()
    {
        _patrolState.Patrolled += OnPatrol;
        _followState.Followed += OnFollow;
        _attackState.Stoped += OnSetFightingStance;
        _attackState.Attacked += OnAttack;
        _enemy.DamageIsDone += OnHurt;
        _deathState.Died += OnDying;
    }

    private void OnDestroy()
    {
        _patrolState.Patrolled -= OnPatrol;
        _followState.Followed -= OnFollow;
        _attackState.Stoped -= OnSetFightingStance;
        _attackState.Attacked -= OnAttack;
        _enemy.DamageIsDone -= OnHurt;
        _deathState.Died -= OnDying;
    }

    private void OnPatrol()
    {
        int runStateIndex = 2;
        float animationSpeed = 1f;

        SetAnimationState(runStateIndex, animationSpeed);
    }

    private void OnFollow()
    {
        int runStateIndex = 2;
        float animationSpeed = 1.5f;

        SetAnimationState(runStateIndex, animationSpeed);
    }

    private float OnAttack()
    {
        _animator.SetTrigger(_attackID);

        return _attackAnimation.length;
    }

    private void OnHurt()
    {
        _animator.SetTrigger(_hurtID);
    }

    private void OnDying()
    {
        _animator.SetTrigger(_deathID);
    }

    private void OnSetFightingStance()
    {
        int fightStanceIndex = 1;
        float animationSpeed = 1f;

        SetAnimationState(fightStanceIndex, animationSpeed);
    }

    private void SetAnimationState(int stateIndex, float animationSpeed)
    {
        _animator.SetInteger(_animStateID, stateIndex);
        _animator.SetFloat(_animationSpeedID, animationSpeed);
    }
}
