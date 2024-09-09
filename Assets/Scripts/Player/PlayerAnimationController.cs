using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Player), typeof(Attacker))]
[RequireComponent (typeof(Jumper), typeof(Player), typeof(PlayerMover))]
public class PlayerAnimationController : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);

    [SerializeField] private GroundChecker _groundChecker;

    private Attacker _attacker;
    private Player _player;
    private Jumper _jumper;
    private PlayerMover _playerMover;

    private int _isMoveID = Animator.StringToHash("IsMove");
    private int _isGroundID = Animator.StringToHash("IsGround");
    private int _isJumpID = Animator.StringToHash("IsJump");
    private int _attackID = Animator.StringToHash("Attack");
    private int _hitID = Animator.StringToHash("Hit");
    private Animator _animator;

    private void Awake()
    {
        _attacker = GetComponent<Attacker>();
        _animator = GetComponent<Animator>();
        _player = GetComponent<Player>();
        _jumper = GetComponent<Jumper>();
        _playerMover = GetComponent<PlayerMover>();
    }

    private void OnEnable()
    {
        _attacker.Attacked += OnAttack;
        _groundChecker.GroundChanged += OnGroundCheck;
        _player.DamageIsDone += OnHit;
        _jumper.Jumped += OnJump;
    }

    private void OnDestroy()
    {
        _attacker.Attacked -= OnAttack;
        _groundChecker.GroundChanged -= OnGroundCheck;
        _player.DamageIsDone -= OnHit;
        _jumper.Jumped -= OnJump;
    }

    private void Update()
    {
        TryMovePlay();
    }

    private void TryMovePlay()
    {
        _animator.SetBool(_isMoveID, _playerMover.IsMove);
    }

    private void OnJump(bool isJumping)
    {
        _animator.SetBool(_isJumpID, isJumping);
    }

    private void OnGroundCheck(bool isGround)
    {
        _animator.SetBool(_isGroundID, isGround);
    }

    private void OnAttack()
    {
        _animator.SetTrigger(_attackID);
    }

    private void OnHit()
    {
        _animator.SetTrigger(_hitID);
    }
}
