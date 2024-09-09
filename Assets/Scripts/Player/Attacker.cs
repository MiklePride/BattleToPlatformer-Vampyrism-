using System;
using System.Collections;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private GameObject _attackZone;
    [SerializeField] private int _damage = 3;
    [SerializeField] private float _cooldown = 1f;
    [SerializeField] private float _delayAttack = 0.3f;
    [SerializeField] private LayerMask _enemyLayer;

    private float _attackRadius = 2f;
    private float _timeSinceLastAttack;
    private Coroutine _attack;

    public event Action Attacked;

    private void Start()
    {
        _timeSinceLastAttack = _cooldown;
    }

    private void Update()
    {
        _timeSinceLastAttack += Time.deltaTime;

        Attack();
    }

    public IEnumerator DoDamage(float delay)
    {
        yield return new WaitForSeconds(delay);

        Collider2D[] enemies = Physics2D.OverlapCircleAll(_attackZone.transform.position, _attackRadius, _enemyLayer);

        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<Enemy>().TakeDamage(_damage);
        }
    }

    private void Attack()
    {
        if (_timeSinceLastAttack >= _cooldown && Input.GetMouseButton(0))
        {
            Attacked?.Invoke();

            if (_attack != null)
                StopCoroutine(_attack);

            _attack = StartCoroutine(DoDamage(_delayAttack));

            _timeSinceLastAttack = 0;
        }
    }
}
