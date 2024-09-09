using UnityEngine;

public class HealthBar : Bar
{
    [SerializeField] private Entity _entity;

    private void OnEnable()
    {
        _entity.HealthChenged += OnChenge;
    }

    private void OnDestroy()
    {
        _entity.HealthChenged -= OnChenge;
    }
}
