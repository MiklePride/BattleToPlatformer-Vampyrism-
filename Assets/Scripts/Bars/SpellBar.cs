using UnityEngine;

public class SpellBar : Bar
{
    [SerializeField] private Spell _spell;

    private void OnEnable()
    {
        _spell.ChargeChenged += OnChenge;
    }

    private void OnDestroy()
    {
        _spell.ChargeChenged -= OnChenge;
    }
}
