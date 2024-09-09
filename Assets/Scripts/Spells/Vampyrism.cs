using System;
using System.Collections;
using UnityEngine;

public class Vampyrism : Spell
{
    [SerializeField] private float _duration;
    [SerializeField] private GameObject _radiusPrefab;
    [SerializeField] private LayerMask _enemyLayer;

    private Player _player;
    private float _healPoint;
    private SpellRadiusRenderer _radiusRenderer;
    private bool _needRecharge = false;

    private Coroutine _coroutine;

    private void Start()
    {
        _player = GetComponent<Player>();
        _healPoint = Damage;
        KeyActive = KeyCode.E;
        _radiusRenderer = new SpellRadiusRenderer(_radiusPrefab, Radius);
        _radiusPrefab.SetActive(false);
    }

    private void Update()
    {
        if (IsSpellReady)
        {
            if (Input.GetKey(KeyActive))
                Activate();
        }

        if (_needRecharge)
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);

            _coroutine = StartCoroutine(Recharge(Cooldown));
        }
    }

    public override void Activate()
    {
        _radiusRenderer.Active();

        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(LifeSteal(_duration));
    }

    private IEnumerator LifeSteal(float currentDuration)
    {
        IsSpellReady = false;

        float second = 1f;
        var waitOneSecond = new WaitForSeconds(second);

        while (currentDuration > 0)
        {
            Enemy enemy = TryGetNearestTarget();

            if (enemy != null)
            {
                enemy.TakeDamage(Damage);
                _player.Heal(_healPoint);
            }

            currentDuration -= second;

            SendMessageAboutChargeChenge(currentDuration, _duration);

            yield return waitOneSecond;
        }

        _radiusRenderer.Inactive();
        _needRecharge = true;
    }

    private IEnumerator Recharge(float cooldown)
    {
        _needRecharge = false;
        float currentCooldown = 0;
        float second = 1f;
        var waitOneSecond = new WaitForSeconds(second);

        while (currentCooldown < cooldown)
        {
            currentCooldown += second;

            SendMessageAboutChargeChenge(currentCooldown, cooldown);

            yield return waitOneSecond;
        }

        IsSpellReady = true;
    }

    private Enemy TryGetNearestTarget()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, Radius, _enemyLayer);

        if (enemies.Length == 0)
            return null;

        if (enemies.Length == 1)
            return enemies[0].GetComponent<Enemy>();

        float distanceToTarget = Vector2.Distance(transform.position, enemies[0].transform.position);
        Collider2D enemy = enemies[0];

        for (int i = 1; i < enemies.Length; i++)
        {
            float distanceToNextTarget = Vector2.Distance(transform.position, enemies[i].transform.position);

            if (distanceToNextTarget < distanceToTarget)
            {
                enemy = enemies[i];
                distanceToTarget = distanceToNextTarget;
            }
        }

        return enemy.GetComponent<Enemy>();
    }
}