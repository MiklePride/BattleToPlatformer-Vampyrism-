using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class DeathTransition : Transition
{
     private Enemy _enemy;

    public override bool NeedTransit => _enemy.IsDeath;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
    }
}
